using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask3
{
    internal interface IRent
    {
        public bool IsBooked { get; }
        public int GetCost(int Months);
        public bool Book(int Months);
    }
}
