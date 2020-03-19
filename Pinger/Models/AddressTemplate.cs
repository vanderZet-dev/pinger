using System;
using System.Collections.Generic;
using System.Text;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public abstract class AddressTemplate : IPingerAddress
    {
        protected string BaseAddress;
        protected PingResultState LastState = PingResultState.NotChecked;
        protected string Message = "Н/Д";

        protected MyProtocolType MyProtocolType;
        protected int CheckInterval;
        

        protected AddressTemplate(string baseAddress, MyProtocolType myProtocolType, int checkInterval)
        {
            BaseAddress = baseAddress;
            MyProtocolType = myProtocolType;
            CheckInterval = checkInterval;
        }

        public virtual dynamic GetEndPoint()
        {
            return BaseAddress;
        }

        public void SetLastState(PingResultState state)
        {
            LastState = state;
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
            return CheckInterval;
        }

        public string GetProtocol()
        {
            return  MyProtocolType.ToString();
        }
    }
}
