using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class DeliveryException : Exception
    {
        public DeliveryException() : base("A csomag nem adhato fel automatabol!"){ }

        public DeliveryException(string message) : base(message){}
    }
}
