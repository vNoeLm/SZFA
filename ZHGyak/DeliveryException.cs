using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class DeliveryException : Exception
    {
        public DeliveryException(string message) : base(message){}
    }
}
