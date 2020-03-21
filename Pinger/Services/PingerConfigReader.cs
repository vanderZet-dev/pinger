using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using Pinger.Interfaces;
using Pinger.Models;
using Pinger.Util;

namespace Pinger.Services
{
    public class PingerConfigReader : IPingerConfigReader
    {
        public List<IPingerAddress> Read()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            var addresses = new List<IPingerAddress>();

            using (StreamReader r = new StreamReader("Addresses.json"))
            {
                try
                {
                    string json = r.ReadToEnd();

                    dynamic configList = JArray.Parse(json);

                    foreach (var config in configList)
                    {
                        string protocol = config.myProtocolType;
                        switch (protocol)
                        {
                            case "Http":
                                addresses.Add(
                                        kernel.Get<IAddressHttp>(new ConstructorArgument("baseAddress", Convert.ToString(config.baseAddress)),
                                            new ConstructorArgument("myProtocolType", Convert.ToString(config.myProtocolType)),
                                            new ConstructorArgument("checkInterval", Convert.ToString(config.checkInterval)),
                                            new ConstructorArgument("prefix", Convert.ToString(config.prefix)),
                                            new ConstructorArgument("validStatusCode", Convert.ToString(config.validStatusCode))
                                        )    
                                    );
                                break;
                            case "Tcp":
                                addresses.Add(
                                    kernel.Get<IAddressTcp>(new ConstructorArgument("baseAddress", Convert.ToString(config.baseAddress)),
                                        new ConstructorArgument("myProtocolType", Convert.ToString(config.myProtocolType)),
                                        new ConstructorArgument("checkInterval", Convert.ToString(config.checkInterval)),
                                        new ConstructorArgument("port", Convert.ToString(config.port))
                                    )
                                );
                                break;
                            case "Icmp":
                                addresses.Add(
                                    kernel.Get<IAddressIcmp>(new ConstructorArgument("baseAddress", Convert.ToString(config.baseAddress)),
                                        new ConstructorArgument("myProtocolType", Convert.ToString(config.myProtocolType)),
                                        new ConstructorArgument("checkInterval", Convert.ToString(config.checkInterval))
                                    )
                                );
                                break;
                        }
                    }
                }
                catch (JsonReaderException e)
                {
                    Console.WriteLine(e);
                }
                catch (RuntimeBinderException e)
                {
                    Console.WriteLine(e);
                }
                catch (JsonSerializationException e)
                {
                    Console.WriteLine(e);
                }
            }

            return addresses;
        }        
    }
}
