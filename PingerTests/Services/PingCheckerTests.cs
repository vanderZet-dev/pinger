using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingCheckerTests
    {
        private StandardKernel _kernel;

        private IPingChecker _pingChecker;

        public PingCheckerTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);

            _pingChecker = _kernel.Get<IPingChecker>();
        }

        [TestMethod]
        public void StartAllCheckers()
        {
            _pingChecker.StartAllCheckers();
        }

    }
}
