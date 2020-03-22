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

            var pingChecker = kernel.Get<IPingChecker>();
            pingChecker.StartAllCheckers();

            Console.ReadKey();
        }
    }
}
