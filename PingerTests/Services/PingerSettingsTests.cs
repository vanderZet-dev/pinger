using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerSettingsTests
    {
        private IPingerSettings _pingerSettings;

        public PingerSettingsTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            _pingerSettings = kernel.Get<IPingerSettings>();
        }

        [TestMethod]
        public void LoadSettingsAndGetAddresses()
        {
            var currentsettingsBeforeLoading = _pingerSettings.GetAddresses();

            Assert.IsTrue(currentsettingsBeforeLoading is null);

            _pingerSettings.LoadSettings();

            var currentsettingsAfterLoading = _pingerSettings.GetAddresses();

            Assert.IsTrue(currentsettingsAfterLoading != null);
        }
    }
}
