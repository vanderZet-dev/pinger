using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Models;
using Pinger.Services;
using Pinger.Tools;
using Pinger.Util;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            var pingerSettings = kernel.Get<IPingerSettings>();
            var pingerHttp = kernel.Get<IPingerHttp>();
            var pingerIcmp = kernel.Get<IPingerIcmp>();
            var pingerTcp = kernel.Get<IPingerTcp>();
            var pingLogWriter = kernel.Get<IPingLogWriter>();

            PingChecker pingChecker = new PingChecker(pingerSettings, pingerHttp, pingerIcmp, pingerTcp, pingLogWriter);
            pingChecker.LoadSettings();
            pingChecker.StartAllCheckers();

            Console.ReadKey();
        }
    }
}
