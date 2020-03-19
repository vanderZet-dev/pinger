using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    public class PingerICMP : IPinger
    {
        public void CheckConnection(IPingerAddress pingerAddress)
        {
            Ping pingSender = new Ping();

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 20000;

            PingOptions options = new PingOptions(64, true);

            try
            {
                // Send the request.
                PingReply reply = pingSender.Send(pingerAddress.GetEndPoint(), timeout, buffer, options);

                if (reply?.Status == IPStatus.Success)
                {
                    pingerAddress.SetLastState(PingResultState.Ok);
                }
                else
                {
                    pingerAddress.SetLastState(PingResultState.Failed);
                    pingerAddress.SetMessage(reply?.Status.ToString());
                }
            }
            catch (PingException ex)
            {
                pingerAddress.SetLastState(PingResultState.Failed);
                pingerAddress.SetMessage(ex.Message);
            }
        }
    }
}
