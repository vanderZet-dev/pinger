using System;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressHTTP : AddressTemplate
    {
        public string Prefix;

        public AddressHTTP(string baseAddress, MyProtocolType myProtocolType, int checkInterval, string prefix) : base(baseAddress, myProtocolType, checkInterval)
        {
            Prefix = prefix;
        }
        
        public override dynamic GetEndPoint()
        {
            return Prefix + "://" + base.GetEndPoint();
        }
    }
}
