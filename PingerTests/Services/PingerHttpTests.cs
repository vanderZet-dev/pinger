using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerHttpTests
    {
        private StandardKernel _kernel;

        private IPingerHttp _pingerHttp;

        public PingerHttpTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);

            _pingerHttp = _kernel.Get<IPingerHttp>();
        }

        [TestMethod]
        public void CheckConnection()
        {
            var addressHttp = _kernel.Get<IAddressHttp>(
                new ConstructorArgument("baseAddress", "ya.ru"),
                new ConstructorArgument("myProtocolType", "Http"),
                new ConstructorArgument("checkInterval", "5"),
                new ConstructorArgument("prefix", "http"),
                new ConstructorArgument("validStatusCode", "200")
            );

            string expectedStatus = "Ok";
            string actualStatus = _pingerHttp.CheckConnection(addressHttp);

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
