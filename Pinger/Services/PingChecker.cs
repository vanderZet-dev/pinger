using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pinger.Interfaces;
using Pinger.Models;

namespace Pinger.Services
{
    public class PingChecker
    {
        private IPingerSettings _pingerSettings;

        private IPingerHttp _pingerHttp;
        private IPingerIcmp _pingerIcmp;
        private IPingerTcp _pingerTcp;

        private IPingLogWriter _pingLogWriter;

        public PingChecker(IPingerSettings pingerSettings,
            IPingerHttp pingerHttp,
            IPingerIcmp pingerIcmp,
            IPingerTcp pingerTcp,
            IPingLogWriter pingLogWriter)
        {
            _pingerSettings = pingerSettings;
            _pingerHttp = pingerHttp;
            _pingerIcmp = pingerIcmp;
            _pingerTcp = pingerTcp;
            _pingLogWriter = pingLogWriter;
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
