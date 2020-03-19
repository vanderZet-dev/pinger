using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pinger.Models;
using Pinger.Models.Enums;

namespace Pinger.Services
{
    public class PingChecker
    {
        private PingerSettings pingerSettings = new PingerSettings();


        public void LoadSettings()
        {
            pingerSettings.LoadSettings();
        }
        public void StartAllCheckers()
        {
            foreach (var address in pingerSettings.Addresses)
            {
                Task.Factory.StartNew(() => ((IPinger)address).CheckConnection());
            }
        }
    }
}
