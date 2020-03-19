using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Exceptions
{
    public class ConnectionFailedException : Exception
    {
        public ConnectionFailedException(string message) : base(message)
        {

        }

        public ConnectionFailedException()
        {

        }

        public override string Message
        {
            get
            {
                if (base.Message != "")
                {
                    return base.Message;
                }
                return "Attempt to establish connection is failed";
            }

        }
    }
}
