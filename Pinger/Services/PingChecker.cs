using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pinger.Models;

namespace Pinger.Services
{
    public class PingChecker
    {
        private PingerSettings _pingerSettings = new PingerSettings();

        private PingerHTTP _pingerHttp = new PingerHTTP();
        private PingerICMP _pingerIcmp = new PingerICMP();
        private PingerTCP _pingerTcp = new PingerTCP();
        
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
                    switch (address.GetType().Name)
                    {
                        case "AddressHTTP":
                            _pingerHttp.CheckConnection(address);
                            break;
                        case "AddressICMP":
                            _pingerIcmp.CheckConnection(address);
                            break;
                        case "AddressTCP":
                            _pingerTcp.CheckConnection(address);
                            Thread.Sleep(5000);
                            break;
                    }
                    Console.WriteLine(address);
                }));
            }

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
