using System;
using System.Collections.Generic;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class PingerSettings : IPingerSettings
    {


        private List<IPingerAddress> _addresses;
        private int _interval;

        public void LoadSettings()
        {
            _addresses = new List<IPingerAddress>
            {
                new AddressHTTP("ya.ru", MyProtocolType.Http, 10, "https"),
                new AddressHTTP("ya.ru", MyProtocolType.Http, 15,"http"),
                new AddressICMP("google.com", MyProtocolType.Icmp, 2),
                new AddressICMP("makler.md", MyProtocolType.Icmp, 2),
                new AddressICMP("makler12345.com", MyProtocolType.Icmp, 2),
                new AddressTCP("127.0.0.1", MyProtocolType.Tcp, 10, "9200"),
                new AddressTCP("127.0.0.2", MyProtocolType.Tcp, 10, "9205")
            };
            _interval = 10;
        }

        public int GetCheckInterval()
        {
            return _interval;
        }

        public List<IPingerAddress> GetAddresses()
        {
            return _addresses;
        }
    }
   
}
