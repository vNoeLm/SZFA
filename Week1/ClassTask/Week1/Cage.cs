using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    internal class Cage
    {
        Animal[] animals;
        int CurrentAnimalCount = 0;

        public Cage(int size)
        {
            this.animals = new Animal[size];
        }

        public static Cage[] ParseData(string DirectoryPath)
        {
            int cageCount = Directory.GetFiles(DirectoryPath).Length;
            Cage[] cages = new Cage[cageCount];

            int CageIndex = 0;
            foreach (string fileName in Directory.GetFiles(DirectoryPath))
            {
                string[] lines = File.ReadAllLines(fileName);
                int LineCount = lines.Length;
                Cage cage = new Cage(LineCount);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    string name = parts[0];
                    Species species = Enum.Parse<Species>(parts[1]);
                    int weight = int.Parse(parts[2]);
                    bool gender = bool.Parse(parts[3]);

                    Animal animal = new Animal(name, gender, weight, species);
                    cage.Add(animal);
                }
                cages[CageIndex] = cage;
                CageIndex++;
            }
            return cages;
        }

        public bool Add(Animal animal)
        {
            if (CurrentAnimalCount < animals.Length)
            {
                animals[CurrentAnimalCount] = animal;
                CurrentAnimalCount++;
                return true;
            }
            return false;
        }

        public void Delete(string name)
        {
            for (int i = 0; i < CurrentAnimalCount; i++)
            {
                if (animals[i].Name == name)
                {
                    animals[i] = animals[CurrentAnimalCount - 1];
                    animals[CurrentAnimalCount - 1] = null;
                    CurrentAnimalCount--;
                }
            }
        }

        public int HowManyGivenSpecies(Species species)
        {
            int count = 0;
            for (int i = 0; i < CurrentAnimalCount; i++)
            {
                if (animals[i].Species == species)
                {
                    count++;
                }
                
            }
            return count;
        }   

        public bool IsThereGivenSpeciesAndGender(Species species, bool gender)
        {
            for (int i = 0; i < CurrentAnimalCount; i++)
            {
                if (animals[i].Species == species && animals[i].Gender == gender)
                {
                    return true;
                }
            }
            return false;
        }

        public Animal[] WhichAreTheGivenSpecies(Species species)
        {
            Animal[] ret = new Animal[CurrentAnimalCount];
            int index = 0;
            for (int i = 0; i < CurrentAnimalCount; i++)
            {
                if (animals[i].Species == species)
                {
                    ret[index] = animals[i];
                    index++;
                }
            }
            Array.Resize(ref ret, index);
            return ret;
        }

        public double AverageWeightOfGivenSpecies(Species species)
        {
            int count = 0;
            int weightSum = 0;
            for (int i = 0; i < CurrentAnimalCount; i++)
            {
                if (animals[i].Species == species)
                {
                    count++;
                    weightSum += animals[i].Weight;
                }
            }
            if (count == 0)
            {
                return 0;
            }
            return (double)weightSum / count;
        }

        public bool InvertedCouple()
        {
            for (int i = 0; i < CurrentAnimalCount - 1; i++)
            {
                for (int j = i + 1; j < CurrentAnimalCount; j++)
                {
                    if (animals[i].Species == animals[j].Species && animals[i].Gender != animals[j].Gender)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Cage GetCageWithMostSpecies(Cage[] cages, Species specie)
        {
            Cage BestCage = null;
            int maxCount = 0;

            foreach (var cage in cages)
            {
                int count = cage.HowManyGivenSpecies(specie);
                if (count > maxCount)
                {
                    maxCount = count;
                    BestCage = cage;
                }
            }
            return BestCage;
        }

        override public string ToString()
        {
            string ret = $"Cage with {CurrentAnimalCount} animals:\n";
            foreach (var animal in animals)
            {
                if (animal != null)
                {
                    ret += "\t" + animal.ToString() + "\n";
                }
            }
            return ret;
        }
    }
}
