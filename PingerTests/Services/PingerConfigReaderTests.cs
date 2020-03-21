using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerConfigReaderTests
    {
        private IPingerConfigReader _pingerConfigReaderTests;

        public PingerConfigReaderTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            _pingerConfigReaderTests = kernel.Get<IPingerConfigReader>();
        }

        [TestMethod]
        public void Read()
        {
            var list = _pingerConfigReaderTests.Read();
            Assert.IsTrue(list.Count>0);
        }
    }
}
