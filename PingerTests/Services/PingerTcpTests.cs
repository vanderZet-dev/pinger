using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerTcpTests
    {
        private StandardKernel _kernel;

        private IPingerTcp _pingerTcp;

        public PingerTcpTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);

            _pingerTcp = _kernel.Get<IPingerTcp>();
        }

        [TestMethod]
        public void CheckConnection()
        {
            var addressTcp = _kernel.Get<IAddressTcp>(
                new ConstructorArgument("baseAddress", "127.0.0.1"),
                new ConstructorArgument("myProtocolType", "Tcp"),
                new ConstructorArgument("checkInterval", "5"),
                new ConstructorArgument("port", "9205")
            );

            string expectedStatus = "Failed";
            string actualStatus = _pingerTcp.CheckConnection(addressTcp);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
