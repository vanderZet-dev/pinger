using System;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressIcmp : AddressTemplate, IAddressIcmp
    {
        public AddressIcmp(string baseAddress, string myProtocolType, string checkInterval) : base(baseAddress, myProtocolType, checkInterval)
        {

        }
    }
}
