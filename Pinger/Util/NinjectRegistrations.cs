using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Models;
using Pinger.Services;

namespace Pinger.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IPingerSettings>().To<PingerSettings>();

            Bind<IPingerHttp>().To<PingerHTTP>();
            Bind<IPingerIcmp>().To<PingerICMP>();
            Bind<IPingerTcp>().To<PingerTCP>();

            Bind<IPingLogWriter>().To<PingLogWriter>();

            Bind<IAddressIcmp>().To<AddressIcmp>();
            Bind<IAddressHttp>().To<AddressHttp>();
            Bind<IAddressTcp>().To<AddressTcp>();

            Bind<IPingerConfigReader>().To<PingerConfigReader>();
            Bind<IPingChecker>().To<PingChecker>();
            Bind<IPingerConfigWriter>().To<PingerConfigWriter>();
            
        }
    }
}
