namespace ClassTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBookItem[] phoneBook = new PhoneBookItem[]
            {
                new PhoneBookItem("cica", 12345),
                new PhoneBookItem("kutya", 1234),
                new PhoneBookItem("cica", 12345),
                new PhoneBookItem("cow", 123)
            };

            OrderedItemsHandler handler = new OrderedItemsHandler(phoneBook);
            Console.WriteLine("---Original---");
            foreach (PhoneBookItem item in handler.items)
            {
                Console.WriteLine($"Név: {item.Name} Telefonszám: {item.PhoneNumber}");
            }

            Console.WriteLine("---Sorted---");
            handler.Sort(SortingMethod.Insertion);
            foreach (PhoneBookItem item in handler.items)
            {
                Console.WriteLine($"Név: {item.Name} Telefonszám: {item.PhoneNumber}");
            }

            Console.WriteLine("---IterativeBinary---");
            PhoneBookItem result = (PhoneBookItem)handler.IterativeBinarySearch(new PhoneBookItem("cica", 12345));
            Console.WriteLine($"Név: {result.Name} Telefonszám: {result.PhoneNumber}");

            Console.WriteLine("---item1---Equals---Item2");
            Console.WriteLine(handler.items[0].Equals(handler.items[1]));

            Console.WriteLine($"---NagyobbVagyEgyenlő---");
            int res = handler.FindIndexOfLargerOrEqualNumber(new PhoneBookItem("cow", 123));
            Console.WriteLine($"Index: {res}");

            Console.WriteLine("---Reversed---");
            handler.Reverse();
            foreach (PhoneBookItem item in handler.items)
            {
                Console.WriteLine($"Név: {item.Name} Telefonszám: {item.PhoneNumber}");
            }
        }
    }
}
