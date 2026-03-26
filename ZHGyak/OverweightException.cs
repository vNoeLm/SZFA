using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class OverweightException : Exception
    {
        public OverweightException() : base("A csomag súlya meghaladja a 2000 grammot!") { }
    }
}
