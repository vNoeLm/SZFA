using System;
using System.Collections.Generic;
using System.Text;

namespace ZH2
{
    internal class TimeException : Exception
    {
        public TimeException(string message) : base(message)
        {
        }
    }
}
