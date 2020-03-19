
using System.Collections.Generic;

namespace Pinger.Interfaces
{
    public interface IPingerSettings
    {
        void LoadSettings();
        List<IPingerAddress> GetAddresses();
    }
}
