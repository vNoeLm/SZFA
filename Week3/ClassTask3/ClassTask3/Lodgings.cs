using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask3
{
    internal class Lodgings : Flat, IRent
    {
        int bookedMonths;

        public Lodgings(double area, int roomCount, int inhabitantsCount, int unitPrice) : base(area, roomCount, inhabitantsCount, unitPrice)
        {
            bookedMonths = 0;
        }

        public bool IsBooked => bookedMonths > 0;

        public bool Book(int Months)
        {
            if (IsBooked)
            {
                return false;
            }
            bookedMonths = Months;
            return true;
        }

        public int GetCost(int Months)
        {
            return InhabitantsCount == 0 ? 0 : (int)TotalValue() / 240 / InhabitantsCount;
        }

        public override bool MoveIn(int newInhabitants)
        {
            if (!IsBooked)
            {
                return false;
            }

            int newInha = InhabitantsCount + newInhabitants;
            if (newInha >  roomCount * 8 || area < newInha * 2)
            {
                return false;
            }
            inhabitantsCount++;
            return true;

        }

        public override string ToString()
        {
            return $"{base.ToString()}\nBooked Months: {bookedMonths}";
        }
    }
}
