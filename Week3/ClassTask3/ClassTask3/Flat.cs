using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask3
{
    internal abstract class Flat : IRealEstate
    {
        protected double area;
        protected int roomCount;
        protected int inhabitantsCount;
        int unitPrice;

        public int InhabitantsCount => inhabitantsCount;

        protected Flat(double area, int roomCount, int inhabitantsCount, int unitPrice)
        {
            this.area = area;
            this.roomCount = roomCount;
            this.inhabitantsCount = inhabitantsCount;
            this.unitPrice = unitPrice;
        }

        public abstract bool MoveIn(int newInhabitants);

        public int TotalValue()
        {
            return (int)area * unitPrice;
        }

        public override string ToString()
        {
            return $"\tFlat Statistics\nArea: {area}\nRooms Count: {roomCount}\nInhabitants Count: {inhabitantsCount}\nUnit Price: {unitPrice}";
        }
    }
}
