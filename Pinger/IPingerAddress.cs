using System;
using System.Collections.Generic;
using System.Text;
using Pinger.Models.Enums;

namespace Pinger
{
    public interface IPingerAddress
    {
        string GetEndPoint();
        void SetLastState(PingResultState state);
        void SetMessage(string message);
    }
}
