using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask3
{
    internal class Garage : IRent, IRealEstate
    {
        double area;
        int unitPrice;
        bool isHeated;
        int months;
        bool isOccupied;

        public Garage(double area, int unitPrice, bool isHeated, int months, bool isOccupied)
        {
            this.area = area;
            this.unitPrice = unitPrice;
            this.isHeated = isHeated;
            this.months = months;
            this.isOccupied = isOccupied;
        }

        public bool IsBooked => months > 0 || isOccupied;

        public bool Book(int Months)
        {
            if (IsBooked)
            {
                return false;
            }
            this.months = Months;
            return true;
        }

        public int GetCost(int Months)
        {
            return (int)(TotalValue() / 120 * months * (isHeated ? 1.5 : 1));
        }

        public int TotalValue()
        {
            return (int)area * unitPrice;
        }

        public void UpdateOccupied()
        {
            isOccupied = !isOccupied;
        }

        public override string ToString()
        {
            return $"Area: {area}\nUnit Price: {unitPrice}\nIs Heated: {isHeated}\nMonths: {months}\nIs Occupied: {isOccupied}";
        }
    }
}
