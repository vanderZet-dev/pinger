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
        private PingerSettings _pingerSettings = new PingerSettings();

        private PingerHTTP _pingerHttp = new PingerHTTP();
        private PingerICMP _pingerIcmp = new PingerICMP();
        private PingerTCP _pingerTcp = new PingerTCP();

        private PingLogWriter _pingLogWriter = new PingLogWriter();

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
