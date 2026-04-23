using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ClassTask
{
    public class NotOrderedItemsException : Exception
    {
        public IComparable[] Items { get; }
        public NotOrderedItemsException(IComparable[] items) : base("A tomb nem megfelelo modon van rendezve!")
        {
            this.Items = items;
        }
    }
}
