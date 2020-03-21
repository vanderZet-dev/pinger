using System;
using System.Net;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressTcp : AddressTemplate, IAddressTcp
    {
        private string _port;

        public AddressTcp(string baseAddress, string myProtocolType, string checkInterval, string port) : base(baseAddress, myProtocolType, checkInterval)
        {
            _port = port;
        }
        
        public override dynamic GetEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(BaseAddress), Convert.ToInt32(_port));
        }

        public override string GetSaveLogName()
        {
            return base.GetSaveLogName() + ":" + _port;
        }

        public override string GetSaveLogData()
        {
            return GetDateTimeLog() + " " + BaseAddress + ":" + _port + " " + GetLastState().ToUpper();
        }
    }
}
