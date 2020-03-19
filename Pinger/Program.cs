using System;
using System.Threading;
using System.Threading.Tasks;
using Pinger.Models;
using Pinger.Services;
using Pinger.Tools;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            PingChecker pingChecker = new PingChecker();
            pingChecker.LoadSettings();
            pingChecker.StartAllCheckers();


            Console.ReadKey();
        }
    }
}
