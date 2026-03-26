using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class NormalParcel : Parcel
    {
        private static Random rnd = new Random();
        public NormalParcel(int weight, string recipient) : base(weight, (Orientation)rnd.Next(0,3), recipient)
        {
        }

        public override double CalculatePrice(bool fromLocker)
        {
            double price = 500 + (1 * Weight);

            if (fromLocker)
            {
                price -= 250;
            }

            return price;
        }
    }
}
