using System;
using System.Collections.Generic;
using System.Text;

namespace ClassTask
{
    internal class PhoneBookItem : IComparable
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }

        public PhoneBookItem(string name, int phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public int CompareTo(object? other)
        {
            if (other == null) throw new ArgumentNullException();

            if (other is not PhoneBookItem && other is not string) throw new ArgumentException();

            if (other is PhoneBookItem item) return this.Name.CompareTo(item.Name);

            return this.Name.CompareTo(other.ToString());
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) throw new ArgumentNullException();

            if (obj is PhoneBookItem item)
            {
                return (this.Name == item.Name && this.PhoneNumber == item.PhoneNumber);
            }
            return false;
        }
    }
}
