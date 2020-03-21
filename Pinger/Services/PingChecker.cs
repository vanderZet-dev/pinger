using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Models;
using Pinger.Util;

namespace Pinger.Services
{
    public class PingChecker : IPingChecker
    {
        private IPingerSettings _pingerSettings;

        private IPingerHttp _pingerHttp;
        private IPingerIcmp _pingerIcmp;
        private IPingerTcp _pingerTcp;

        private IPingLogWriter _pingLogWriter;

        public PingChecker()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            _pingerSettings = kernel.Get<IPingerSettings>();
            _pingerHttp = kernel.Get<IPingerHttp>();
            _pingerIcmp = kernel.Get<IPingerIcmp>();
            _pingerTcp = kernel.Get<IPingerTcp>();
            _pingLogWriter = kernel.Get<IPingLogWriter>();
        }

        public void LoadSettings()
        {
            _pingerSettings.LoadSettings();
        }

        public void StartAllCheckers()
        {
            List<Task> tasks = new List<Task>();

            foreach (var address in _pingerSettings.GetAddresses())
            {
                tasks.Add(new Task(() =>
                {
                    while (true)
                    {
                        switch (address.GetProtocol())
                        {
                            case "Http":
                                _pingerHttp.CheckConnection(address);
                                break;
                            case "Icmp":
                                _pingerIcmp.CheckConnection(address);
                                break;
                            case "Tcp":
                                _pingerTcp.CheckConnection(address);
                                break;
                        }
                        Console.WriteLine(((IPingerLogSaveble)address).GetSaveLogData());
                        _pingLogWriter.SaveLog(address as IPingerLogSaveble);
                        Thread.Sleep(address.GetCheckInterval());
                    }
                }));
            }

            foreach (var task in tasks)
            {
                task.Start();
            }
        }
    }
}
