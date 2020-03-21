using System.Collections.Generic;

namespace Pinger.Interfaces
{
    public interface IPingerConfigReader
    {
        List<IPingerAddress> Read();
    }
}
