using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Pinger.Exceptions;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    public class PingerHTTP : IPinger
    {
        public void CheckConnection(IPingerAddress pingerAddress)
        {
            WebRequest request = WebRequest.Create(pingerAddress.GetEndPoint());
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                try
                {
                    if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    {
                        throw new ConnectionFailedException();
                    }

                    pingerAddress.SetLastState(PingResultState.Ok);
                }
                catch (UriFormatException ex)
                {
                    pingerAddress.SetLastState(PingResultState.Failed);
                    pingerAddress.SetMessage(ex.Message);
                }
            }
        }
    }
}
