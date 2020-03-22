using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Pinger.Interfaces;
using Pinger.Services;
using Pinger.Util;

namespace PingerTests.Services
{
    [TestClass]
    public class PingLogWriterTests
    {
        private StandardKernel _kernel;

        private IPingLogWriter _pingLogWriter;

        public PingLogWriterTests()
        {
            NinjectModule registrations = new NinjectRegistrations();
            _kernel = new StandardKernel(registrations);

            _pingLogWriter = _kernel.Get<IPingLogWriter>();
        }

        [TestMethod]
        public void SaveLog()
        {
            string directory = "PingerLogs";
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }

            var addressHtml = _kernel.Get<IAddressHttp>(
                new ConstructorArgument("baseAddress", "ya.ru"),
                new ConstructorArgument("myProtocolType", "Http"),
                new ConstructorArgument("checkInterval", "5"),
                new ConstructorArgument("prefix", "http"),
                new ConstructorArgument("validStatusCode", "200")
            );

            addressHtml.SetLastState("Ok");

            string expectedCreatedLogFileName = "http__ya_ru.txt";

            string expectedBaseAddressData = "http://ya.ru";
            string expectedStatusData = "OK";

            Regex regex = new Regex(@"\s");
            string[] actualLogData = regex.Split(_pingLogWriter.SaveLog(addressHtml));

            Assert.IsTrue(Directory.Exists(directory));

            Assert.IsTrue(File.Exists(directory + "/" + expectedCreatedLogFileName));

            Assert.AreEqual(expectedBaseAddressData, actualLogData[2]);

            Assert.AreEqual(expectedStatusData, actualLogData[3]);
        }
    }
}
