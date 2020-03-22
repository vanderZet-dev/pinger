using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public abstract class AddressTemplate : IPingerAddress, IPingerLogSaveble
    {
        protected string BaseAddress;
        protected PingResultState LastState = PingResultState.NotChecked;
        protected string Message = "Н/Д";

        protected MyProtocolType MyProtocolType;
        protected string CheckInterval;

        protected AddressTemplate()
        {

        }

        protected AddressTemplate(string baseAddress, string myProtocolType, string checkInterval)
        {
            BaseAddress = baseAddress;
            MyProtocolType = Enum.Parse<MyProtocolType>(myProtocolType);
            CheckInterval = checkInterval;
        }

        public virtual dynamic GetEndPoint()
        {
            return BaseAddress;
        }

        public void SetLastState(string state)
        {
            LastState = Enum.Parse<PingResultState>(state);
        }

        public void SetMessage(string message)
        {
            Message = message;
        }

        public string GetLastState()
        {
            return LastState.ToString();
        }

        public string GetMessage()
        {
            return Message;
        }

        public override string ToString()
        {
            return $"{GetType().Name} | EndPoint to ping: {GetEndPoint()} | LastState : {LastState}" + (Message != "Н/Д" ? $" | Message: {Message}" : "");
        }

        public int GetCheckInterval()
        {
            return Convert.ToInt32(CheckInterval)*1000;
        }

        public string GetProtocol()
        {
            return  MyProtocolType.ToString();
        }

        public virtual string GetSaveLogName()
        {
            return $"{BaseAddress}";
        }

        public virtual string GetSaveLogData()
        {
           return GetDateTimeLog() + " " + BaseAddress + " " + GetLastState().ToUpper();
        }

        protected string GetDateTimeLog()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
