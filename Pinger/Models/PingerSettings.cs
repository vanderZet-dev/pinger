﻿using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Models.Enums;
using Pinger.Services;
using Pinger.Util;

namespace Pinger.Models
{
    public class PingerSettings : IPingerSettings
    {

        private List<IPingerAddress> _addresses;

        public void LoadSettings()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            var pingerConfigReader = kernel.Get<IPingerConfigReader>();
            _addresses = pingerConfigReader.Read();
        }

        public List<IPingerAddress> GetAddresses()
        {
            return _addresses;
        }
    }
   
}
