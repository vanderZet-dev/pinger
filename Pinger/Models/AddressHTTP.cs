using System;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressHttp : AddressTemplate, IPingerAdressWithValidation, IAddressHttp
    {
        private string _prefix;
        private string _validStatusCode;

        public AddressHttp()
        {

        }

        public AddressHttp(string baseAddress, string myProtocolType, string checkInterval, string prefix, string validStatusCode) : base(baseAddress, myProtocolType, checkInterval)
        {
            _prefix = prefix;
            _validStatusCode = validStatusCode;
        }
        
        public override dynamic GetEndPoint()
        {
            return _prefix + "://" + base.GetEndPoint();
        }

        public override string GetSaveLogName()
        {
            return GetEndPoint();
        }

        public int GetValidStatusCode()
        {
            return Convert.ToInt32(_validStatusCode);
        }

        public override string GetSaveLogData()
        {
            return GetDateTimeLog() + " " + GetEndPoint() + " " + GetLastState().ToUpper();
        }
    }
}
