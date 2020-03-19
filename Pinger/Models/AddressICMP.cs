using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressICMP : AddressTemplate
    {
        
        public AddressICMP(string baseAddress, MyProtocolType myProtocolType, int checkInterval) : base(baseAddress, myProtocolType, checkInterval)
        {

        }
    }
}
