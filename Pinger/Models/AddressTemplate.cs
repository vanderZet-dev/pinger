using System;
using System.Collections.Generic;
using System.Text;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public abstract class AddressTemplate : IPingerAddress
    {
        public string BaseAddress { get; set; }
        public PingResultState LastState { get; set; } = PingResultState.NotChecked;
        public string Message { get; set; } = "Н/Д";

        protected AddressTemplate(string baseAddress)
        {
            BaseAddress = baseAddress;
        }

        public virtual string GetEndPoint()
        {
            return BaseAddress;
        }

        public override string ToString()
        {
            return $"{GetType().Name} | EndPoint to ping: {GetEndPoint()} | LastState : {LastState}" + (Message != "Н/Д" ? $" | Message: {Message}" : "");
        }

        public void SetLastState(PingResultState state)
        {
            LastState = state;
        }

        public void SetMessage(string message)
        {
            Message = message;
        }
    }
}
