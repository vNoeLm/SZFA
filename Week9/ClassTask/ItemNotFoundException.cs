using System;
using System.Collections.Generic;
using System.Text;

namespace ClassTask
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException() : base("Az elem nem talalhato!")
        {
        }
    }
}
