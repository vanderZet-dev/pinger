
using System.Collections.Generic;

namespace Pinger.Interfaces
{
    public interface IPingerSettings
    {
        void LoadSettings();
        int GetCheckInterval();
        List<IPingerAddress> GetAddresses();
    }
}
