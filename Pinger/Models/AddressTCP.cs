using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Pinger.Exceptions;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    [Serializable]
    public class AddressTCP : AddressTemplate, IPinger
    {
        public string Port;
        

        public AddressTCP(string baseAddress, string port) : base(baseAddress)
        {
            Port = port;
        }
        
        public override string GetEndPoint()
        {
            return base.GetEndPoint() + ":" + Port;
        }

        public void CheckConnection()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(BaseAddress), Convert.ToInt32(Port));
            using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    sock.Connect(ipPoint);

                    if (!sock.Connected)
                    {
                        throw new ConnectionFailedException();
                    }
                    SetLastState(PingResultState.Ok);
                }
                catch (FormatException ex)
                {
                    SetLastState(PingResultState.Failed);
                    SetMessage(ex.Message);
                }
                catch (ConnectionFailedException ex)
                {
                    SetLastState(PingResultState.Failed);
                    SetMessage(ex.Message);
                }
                catch (SocketException ex)
                {
                    SetLastState(PingResultState.Failed);
                    SetMessage(ex.Message);
                }
            }
            Console.WriteLine(this);
        }
    }
}
