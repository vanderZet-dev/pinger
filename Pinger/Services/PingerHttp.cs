using System;
using System.Net;
using Pinger.Exceptions;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Services
{
    public class PingerHTTP : IPingerHttp
    {
        public string CheckConnection(IPingerAddress pingerAddress)
        {
            WebRequest request = WebRequest.Create(pingerAddress.GetEndPoint());
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                try
                {
                    int statusCode = (int)((HttpWebResponse)response).StatusCode;
                    int? validCode = ((IPingerAdressWithValidation) pingerAddress)?.GetValidStatusCode();
                    if (!Equals(statusCode, validCode))
                    {
                        throw new ConnectionFailedException();
                    }

                    pingerAddress.SetLastState("Ok");
                }
                catch (UriFormatException ex)
                {
                    pingerAddress.SetLastState("Failed");
                    pingerAddress.SetMessage(ex.Message);
                }
                catch (ConnectionFailedException ex)
                {
                    pingerAddress.SetLastState("Failed");
                    pingerAddress.SetMessage(ex.Message);
                }
            }

            return pingerAddress.GetLastState();
        }
    }
}
