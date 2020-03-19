using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressICMP : AddressTemplate, IPinger
    {
        
        public AddressICMP(string baseAddress) :base(baseAddress)
        {

        }

        public void CheckConnection()
        {
            Ping pingSender = new Ping();

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 20000;

            PingOptions options = new PingOptions(64, true);

            try
            {
                // Send the request.
                PingReply reply = pingSender.Send(GetEndPoint(), timeout, buffer, options);

                if (reply?.Status == IPStatus.Success)
                {
                    SetLastState(PingResultState.Ok);
                }
                else
                {
                    SetLastState(PingResultState.Failed);
                    SetMessage(reply?.Status.ToString());
                }
            }
            catch (PingException ex)
            {
                SetLastState(PingResultState.Failed);
                SetMessage(ex.Message);
            }
        }
    }
}
