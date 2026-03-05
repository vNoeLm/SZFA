using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask3
{
    internal class FamilyApartment : Flat
    {
        int childrenCount;

        public FamilyApartment(double area, int roomCount, int inhabitantsCount, int unitPrice) : base(area, roomCount, inhabitantsCount, unitPrice)
        {
            childrenCount = 0;
        }
        public bool ChildIsBorn()
        {
            if (InhabitantsCount - childrenCount < 2)
            {
                return false;
            }
            childrenCount++;
            inhabitantsCount++;
            return true;
        }

        public override bool MoveIn(int newInhabitants)
        {
            int adults = inhabitantsCount - childrenCount;
            int newAdult = adults + newInhabitants;

            if (roomCount * 2 < (newAdult * 2 * childrenCount) || area > (newAdult * 2 * childrenCount) * 10)
            {
                return false;
            }
            inhabitantsCount += newInhabitants;
            return true;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nChildren Count: {childrenCount}";
        }
    }
}
