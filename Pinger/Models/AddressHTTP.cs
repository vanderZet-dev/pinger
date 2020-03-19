using System;
using System.Globalization;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressHTTP : AddressTemplate, IPingerAdressWithValidation
    {
        private string _prefix;
        private int _validStatusCode;

        public AddressHTTP(string baseAddress, MyProtocolType myProtocolType, int checkInterval, string prefix, int validStatusCode) : base(baseAddress, myProtocolType, checkInterval)
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
            return _validStatusCode;
        }

        public override string GetSaveLogData()
        {
            return GetDateTimeLog() + " " + GetEndPoint() + " " + GetLastState().ToUpper();
        }
    }
}
