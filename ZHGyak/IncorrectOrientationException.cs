using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class IncorrectOrientationException : DeliveryException
    {
        public Parcel AffectedParcel { get; }

        public IncorrectOrientationException(Parcel parcel) : base("A törékeny csomag nem lehet tetszoleges!")
        {
            AffectedParcel = parcel;
        }
    }
}
