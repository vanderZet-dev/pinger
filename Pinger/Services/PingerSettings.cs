using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Util;

namespace Pinger.Services
{
    public class PingerSettings : IPingerSettings
    {
        private IPingerConfigReader _pingerConfigReader;

        private List<IPingerAddress> _addresses;        

        public PingerSettings(IPingerConfigReader pingerConfigReader)
        {
            _pingerConfigReader = pingerConfigReader;
        }

        public void LoadSettings()
        {                  
            _addresses = _pingerConfigReader.Read();
        }

        public List<IPingerAddress> GetAddresses()
        {
            return _addresses;
        }
    }
   
}
