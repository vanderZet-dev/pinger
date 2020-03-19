using System;
using System.Net;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressTCP : AddressTemplate
    {
        public string Port;

        public AddressTCP(string baseAddress, MyProtocolType myProtocolType, int checkInterval, string port) : base(baseAddress, myProtocolType, checkInterval)
        {
            Port = port;
        }
        
        public override dynamic GetEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(BaseAddress), Convert.ToInt32(Port));
        }
        
    }
}
