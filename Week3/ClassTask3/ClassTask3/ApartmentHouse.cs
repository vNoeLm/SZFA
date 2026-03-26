using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask3
{
    internal class ApartmentHouse
    {
        int flatsCount;
        int garageCount;
        int maxFlats;
        int maxGarage;

        public IRealEstate[] RealEstates { get; private set; }
        public ApartmentHouse(int maxFlats, int maxGarage)
        {
            this.maxFlats = maxFlats;
            this.maxGarage = maxGarage;
            RealEstates = new IRealEstate[this.maxFlats + this.maxGarage];
        }
        public bool Add(Flat flat)
        {
            if (flatsCount == maxFlats)
            {
                return false;
            }
            RealEstates[flatsCount + garageCount] = flat;
            flatsCount++;
            return true;
        }

        public bool Add(Garage garage)
        {
            if (garageCount == maxGarage)
            {
                return false;
            }
            RealEstates[flatsCount + garageCount] = garage;
            garageCount++;
            return true;
        }

        public int InhabitantsCount
        {
            get
            {
                int count = 0;
                foreach (IRealEstate estate in RealEstates)
                {
                    count += (estate as Flat)?.InhabitantsCount ?? 0;
                }
                return count;
            }
        }

        public int TotalValue()
        {
            int total = 0;
            foreach (IRealEstate estate in RealEstates)
            {
                if (estate is Flat flat && flat.InhabitantsCount > 0 || estate is Garage garage && garage.IsBooked)
                {
                    total += estate.TotalValue();
                }
            }
            return total;
        }

        public static ApartmentHouse LoadFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            ApartmentHouse apartment = new ApartmentHouse(lines.Length, lines.Length);

            foreach (string line in lines)
            {
                string[] cells = line.Split(' ');
                switch (cells[0])
                {
                    case "Alberlet":
                        apartment.Add(new Lodgings(double.Parse(cells[1]), int.Parse(cells[2]), int.Parse(cells[3]), int.Parse(cells[4])));
                        break;
                    case "CsaladiApartman":
                        apartment.Add(new FamilyApartment(double.Parse(cells[1]), int.Parse(cells[2]), int.Parse(cells[3]), int.Parse(cells[4])));
                        break;
                    case "Garazs":
                        apartment.Add(new Garage(double.Parse(cells[1]), int.Parse(cells[2]), cells[3] == "futott", int.Parse(cells[4]), cells[5] == "asd"));
                        break;
                }
            }
            return apartment;
        }
    }
}
