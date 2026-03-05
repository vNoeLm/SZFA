namespace ClassTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comic[] comics =
            [
                                new() { Author = "Stan Lee", Title = "Spider-Man", PageCount = 780 },
                                new() { Author = "Frank Miller", Title = "The Dark Knight Returns", PageCount = 200 },
                                new() { Author = "Alan Moore", Title = "Watchmen", PageCount = 550 }
            ];
            Console.WriteLine("Befire Sorting: ");
            foreach (var comic in comics)
            {
                Console.WriteLine(comic);
            }
            Console.WriteLine("---------------------------------");
            Array.Sort(comics);
            Console.WriteLine("After Sorting: ");
            foreach (var comic in comics)
            {
                Console.WriteLine(comic);
            }
        }
    }
}
