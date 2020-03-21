using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Interfaces
{
    public interface IPinger
    {
        void CheckConnection(IPingerAddress pingerAddress);
    }
}
