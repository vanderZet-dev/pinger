using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Pinger.Exceptions;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressHTTP : AddressTemplate, IPinger
    {
        public string Prefix;

        public AddressHTTP(string baseAddress, string prefix) : base(baseAddress)
        {
            Prefix = prefix;
        }
        
        public override string GetEndPoint()
        {
            return Prefix + "://" + base.GetEndPoint();
        }

        public void CheckConnection()
        {
            WebRequest request = WebRequest.Create(GetEndPoint());
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                try
                {
                    if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
                    {
                        throw new ConnectionFailedException();
                    }

                    SetLastState(PingResultState.Ok);
                }
                catch (UriFormatException ex)
                {
                    SetLastState(PingResultState.Failed);
                    SetMessage(ex.Message);
                }
            }
            Console.WriteLine(this);
        }
    }
}
