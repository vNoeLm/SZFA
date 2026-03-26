using System;
using System.Collections.Generic;
using System.Text;

namespace ZHGyak
{
    public class Courier
    {
        private IDeliverable[] items;
        private int count;
        int totalWeight;
        public int TotalWeight => totalWeight;
        public Courier(int size)
        {
            items = new IDeliverable[size];
            count = 0;
            totalWeight = 0;
        }

        public void PickUpItem(IDeliverable item)
        {
            if (count >= items.Length)
            {
                throw new DeliveryException("A futár tömbje megtelt!");
            }

            items[count] = item;

            totalWeight += item.Weight;

            count++;
        }

        public IDeliverable[] FragilesSorted()
        {
            int fragileCount = 0;
            foreach (var item in items)
            {
                if (item is FragileParcel) fragileCount++;
            }

            IDeliverable[] fragiles = new IDeliverable[fragileCount];
            int index = 0;

            foreach (var item in items)
            {
                if (item is FragileParcel)
                {
                    fragiles[index] = item;
                    index++;
                }
            }

            Array.Sort(fragiles);

            return fragiles;
        }
    }
}
