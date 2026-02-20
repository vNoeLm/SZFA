namespace Week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cage[] cages = Cage.ParseData("C:\\Users\\Noel\\Documents\\GitHub\\SZFA\\Week1\\Week1\\CageContent\\");

            for (int i = 0; i < cages.Length; i++)
            {
                Cage currentCage = cages[i];

                Console.WriteLine($"\n================================================================");
                Console.WriteLine($"CAGE #{i + 1}");
                Console.WriteLine($"================================================================");

                Console.WriteLine($"Original Content:");
                Console.WriteLine(currentCage);
                Console.WriteLine($"----------------------------------------------------------------");

                Console.WriteLine($"Action: Deleting 'Rex'");
                currentCage.Delete("Rex");
                Console.WriteLine(currentCage);
                Console.WriteLine($"----------------------------------------------------------------");

                Console.WriteLine($"How many dogs in the cage: {currentCage.HowManyGivenSpecies(Species.Dog)}");

                bool hasMaleRabbit = currentCage.IsThereGivenSpeciesAndGender(Species.Rabbit, true);
                Console.WriteLine($"Is there a male rabbit in the cage: {(hasMaleRabbit ? "Yes" : "No")}");

                Console.WriteLine($"Which animals are dogs in the cage:");
                Animal[] dogs = currentCage.WhichAreTheGivenSpecies(Species.Dog);
                if (dogs.Length > 0)
                {
                    foreach (var dog in dogs)
                    {
                        Console.WriteLine($"\t{dog}");
                    }
                }
                else
                {
                    Console.WriteLine("\tThere are no Dogs in the cage!");
                }

                Console.WriteLine($"Average weight of dogs: {currentCage.AverageWeightOfGivenSpecies(Species.Dog):F2} kg");

                bool hasCouple = currentCage.InvertedCouple();
                Console.WriteLine($"Is there an inverted couple?: {(hasCouple ? "Yes" : "No")}");
                Console.WriteLine($"----------------------------------------------------------------");
            }

            Console.WriteLine($"================================================================");
            Cage mostPandas = Cage.GetCageWithMostSpecies(cages, Species.Panda);
            if (mostPandas != null)
            {
                Console.WriteLine($"Cage with the most pandas:\n{mostPandas}");
            }
            else
            {
                Console.WriteLine("No pandas found in any cage.");
            }
            Console.WriteLine($"================================================================");
        }
    }
}
