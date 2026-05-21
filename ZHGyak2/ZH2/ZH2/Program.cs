namespace ZH2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Races Eredmenyek = ReadFolder("eredmenyek_mappa");

            string runnerName = "Jani";
            Time best = Eredmenyek.BestPerformance(runnerName);

            if (best != null)
                Console.WriteLine($"{runnerName} legjobb ideje: {best.ToString()}");
            else
                Console.WriteLine($"{runnerName} még nem indult versenyen.");

            Time lower = Time.Parse("01:45:00");
            Time upper = Time.Parse("02:00:00");

            RunnerWithTime[] filteredRunners = Eredmenyek.AllBetween(lower, upper);

            Console.WriteLine("\nFélmaraton eredmények (01:45:00 - 02:00:00):");
            foreach (var runner in filteredRunners)
            {
                Console.WriteLine($"{runner.Name}: {runner.Time.ToString()}");
            }

        }

        static string[] ReadFile(string path)
        {
            string[] allLines = File.ReadAllLines(path);

            int count = int.Parse(allLines[0]);

            string[] dataOnly = new string[count];
            for (int i = 0; i < count; i++)
            {
                dataOnly[i] = allLines[i + 1];
            }

            return dataOnly;
        }

        static Races ReadFolder(string path)
        {
            string[] files = Directory.GetFiles(path, "*.txt");
            RaceResults[] raceResultsArray = new RaceResults[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                string[] lines = ReadFile(files[i]);

                raceResultsArray[i] = new RaceResults(lines.Length, lines);
            }

            return new Races(raceResultsArray);
        }
    }
}
