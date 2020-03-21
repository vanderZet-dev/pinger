using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingerConfigWriterTests
    {
        private IPingerConfigWriter _pingerConfigWriter;

        public PingerConfigWriterTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            _pingerConfigWriter = kernel.Get<IPingerConfigWriter>();
        }

        [TestMethod]
        public void Write()
        {
            string newFileWithConfig = "TestConfigs.json";

            File.Delete(newFileWithConfig);

            _pingerConfigWriter.Write(newFileWithConfig);

            Assert.IsTrue(File.Exists(newFileWithConfig));
        }
    }
}
