namespace ClassTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6};
            ArrayStatistics statistics = new ArrayStatistics(nums);
            Console.WriteLine(statistics.Sum());
        }
    }
}
