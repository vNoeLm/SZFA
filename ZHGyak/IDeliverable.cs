using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public interface IDeliverable
    {
        int Weight { get; set; }
        string Address { get; set; }

        public double CalculatePrice(bool fromLocker);
    }
}
