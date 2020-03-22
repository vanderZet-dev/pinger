using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    public class PingerIcmpTests
    {
        private StandardKernel _kernel;

        private IPingerIcmp _pingerIcmp;

        public PingerIcmpTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);

            _pingerIcmp = _kernel.Get<IPingerIcmp>();
        }

        [TestMethod]
        public void CheckConnection()
        {
            var addressIcmp = _kernel.Get<IAddressIcmp>(
                new ConstructorArgument("baseAddress", "google.com"),
                new ConstructorArgument("myProtocolType", "Icmp"),
                new ConstructorArgument("checkInterval", "2")
            );

            string expectedStatus = "Ok";
            string actualStatus = _pingerIcmp.CheckConnection(addressIcmp);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
