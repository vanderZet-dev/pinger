using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerSettingsTests
    {
        public PingerSettingsTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
        }

        [TestMethod]
        public void LoadSettings()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetAddresses()
        {
            Assert.IsTrue(false);
        }
    }
}
