using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Interfaces
{
    public interface IPinger
    {
        string CheckConnection(IPingerAddress pingerAddress);
    }
}
