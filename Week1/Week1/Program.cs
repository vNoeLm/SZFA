namespace Week1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cage cage = new Cage(10);
            Animal animal = new Animal("Doggo", true, 20, Species.Rabbit);
            Animal animal1 = new Animal("Cukker", false, 100, Species.Panda);
            Animal animal2 = new Animal("Pani", true, 5, Species.Panda);
            Animal animal3 = new Animal("Doggy", false, 25, Species.Dog);
            cage.Add(animal);
            cage.Add(animal1);
            cage.Add(animal2);
            cage.Add(animal3);

            Cage cage2 = new Cage(10);
            Animal animal4 = new Animal("Doggo2", true, 22, Species.Dog);
            Animal animal5 = new Animal("Cukker2", false, 110, Species.Panda);
            Animal animal6 = new Animal("Pandy", true, 6, Species.Panda);
            Animal animal7 = new Animal("Doggy2", false, 27, Species.Panda);
            cage2.Add(animal4);
            cage2.Add(animal5);
            cage2.Add(animal6);
            cage2.Add(animal7);


            Console.WriteLine($"Original Cage:");
            Console.WriteLine(cage);
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"After deleting Panda:");
            cage.Delete("Panda");
            Console.WriteLine(cage);
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"How many dogs in the cage: {cage.HowManyGivenSpecies(Species.Dog)}");
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"Is there a male rabbit in the cage: {(cage.IsThereGivenSpeciesAndGender(Species.Rabbit, true) ? "Yes" : "No")}");
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"Which animals are dogs in the cage:");
            Animal[] dogs = cage.WhichAreTheGivenSpecies(Species.Dog);
            foreach (var dog in dogs)
            {
                Console.WriteLine($"\t{dog}");
            }
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"Average weight of dogs in the cage: {cage.AverageWeightOfGivenSpecies(Species.Dog)}");
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"Is there an inverted couple in the cage: {(cage.InvertedCouple() ? "Yes" : "No")}");
            Console.WriteLine($"----------------------------------------------------------------");

            Console.WriteLine($"Cage with most pandas: {Cage.GetCageWithMostSpecies(new Cage[] { cage, cage2 }, Species.Rabbit)}");
            Console.WriteLine($"----------------------------------------------------------------");
        }
    }
}
