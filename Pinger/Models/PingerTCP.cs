using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Pinger.Exceptions;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Models
{
    public class PingerTCP : IPingerTcp
    {
        public void CheckConnection(IPingerAddress pingerAddress)
        {
            var ipPoint = pingerAddress.GetEndPoint();
            using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    sock.Connect(ipPoint);

                    if (!sock.Connected)
                    {
                        throw new ConnectionFailedException();
                    }
                    pingerAddress.SetLastState(PingResultState.Ok);
                }
                catch (FormatException ex)
                {
                    pingerAddress.SetLastState(PingResultState.Failed);
                    pingerAddress.SetMessage(ex.Message);
                }
                catch (ConnectionFailedException ex)
                {
                    pingerAddress.SetLastState(PingResultState.Failed);
                    pingerAddress.SetMessage(ex.Message);
                }
                catch (SocketException ex)
                {
                    pingerAddress.SetLastState(PingResultState.Failed);
                    pingerAddress.SetMessage(ex.Message);
                }
            }
        }
    }
}
