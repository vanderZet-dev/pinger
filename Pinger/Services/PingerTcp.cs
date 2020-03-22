using System;
using System.Net.Sockets;
using Pinger.Exceptions;
using Pinger.Interfaces;
using Pinger.Models.Enums;

namespace Pinger.Services
{
    public class PingerTCP : IPingerTcp
    {
        public string CheckConnection(IPingerAddress pingerAddress)
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
                    pingerAddress.SetLastState("Ok");
                }
                catch (FormatException ex)
                {
                    pingerAddress.SetLastState("Failed");
                    pingerAddress.SetMessage(ex.Message);
                }
                catch (ConnectionFailedException ex)
                {
                    pingerAddress.SetLastState("Failed");
                    pingerAddress.SetMessage(ex.Message);
                }
                catch (SocketException ex)
                {
                    pingerAddress.SetLastState("Failed");
                    pingerAddress.SetMessage(ex.Message);
                }
            }

            return pingerAddress.GetLastState();
        }
    }
}
