using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Interfaces
{
    interface IPinger
    {
        void CheckConnection(IPingerAddress pingerAddress);
    }
}
