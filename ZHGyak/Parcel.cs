using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public enum Orientation
    {
        Horizontal,
        Vertical,
        Arbitrary
    }
    public abstract class Parcel : IDeliverable, IComparable
    {

        public int Weight { get; set; }
        public string Address { get; set; }

        public Orientation Orient { get; private set; }
        public string Recipient { get; set; }

        protected Parcel(int weight, Orientation orient, string recipient)
        {
            this.Weight = weight;
            this.Orient = orient;
            this.Recipient = recipient;
        }

        protected Parcel(string recipient, int weight)
        {
            Recipient = recipient;
            Weight = weight;
        }

        public abstract double CalculatePrice(bool fromLocker);

        public int CompareTo(object? obj)
        {
            if (obj is Parcel other)
            {
                return this.Weight.CompareTo(other.Weight);

            }
            else
            {
                throw new ArgumentException("Object is not a Parcel");
            }
        }

        override public string ToString()
        {
            return $"Címzett: {Recipient} / Tömeg: {Weight} g / Elhelyezés: {Orient}";
        }
    }
}
