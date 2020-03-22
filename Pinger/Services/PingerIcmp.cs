using System.Net.NetworkInformation;
using System.Text;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Services
{
    public class PingerICMP : IPingerIcmp
    {
        public string CheckConnection(IPingerAddress pingerAddress)
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
                    pingerAddress.SetLastState("Ok");
                }
                else
                {
                    pingerAddress.SetLastState("Failed");
                    pingerAddress.SetMessage(reply?.Status.ToString());
                }
            }
            catch (PingException ex)
            {
                pingerAddress.SetLastState("Failed");
                pingerAddress.SetMessage(ex.Message);
            }

            return pingerAddress.GetLastState();
        }
    }
}
