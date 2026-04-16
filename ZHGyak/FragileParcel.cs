using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class FragileParcel : Parcel
    {
        public FragileParcel(int weight, Orientation orient, string recipient) : base(weight, orient, recipient)
        {
            if (orient == Orientation.Arbitrary)
            {
                throw new IncorrectOrientationException(this);
            }
        }

        public override double CalculatePrice(bool fromLocker)
        {
            if (fromLocker)
            {
                throw new DeliveryException("A csomagot nem lehet automatánol feladni!");
            }
            int price = 1000 + (2 * Weight);
            return price;
        }
    }
}
