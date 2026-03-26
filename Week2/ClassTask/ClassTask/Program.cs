using System.Drawing;
namespace ClassTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[100];

            void MakeRecOrSquare(double side1, double side2, Color color, bool isHoley)
            {
                int index = 0;
                foreach (Shape shape in shapes)
                {
                    if (shape != null)
                    {
                        index++;
                    }
                }
                if (side1 == side2)
                {
                    shapes[index + 1] = new Square(side1, color, isHoley);
                }
                else
                {
                    shapes[index + 1] = new Rectangle(side1, side2, color, isHoley);
                }
            }

            for (int i = 10; i <  15; i++)
            {
                for (int j = 10; j < 13; j++)
                {
                    MakeRecOrSquare(i, j, Color.AliceBlue, false);
                }
            }

            foreach (Shape shape in shapes)
            {
                if (shape != null)
                {
                    Console.WriteLine(shape.ToString());
                }
            }
            Console.WriteLine($"---------------ASD---------------------");
            foreach (Shape shape in shapes)
            {
                if (shape != null)
                {
                    if (shape.Area() > shape.Perimeter())
                    {
                        shape.MakeHoley();
                    }
                    Console.WriteLine(shape.ToString());
                }
            }

            void BiggestShape()
            {
                double biggestArea = 0;
                int index = 0;
                int bigInd = 0;
                foreach (Shape shape in shapes)
                {
                    if (shape != null)
                    {
                        if (biggestArea <  shape.Area())
                        {
                            biggestArea = shape.Area();
                            bigInd = index;
                        }
                        index++;
                    }
                }
                Console.WriteLine($"A legnagyobb object a: {shapes[bigInd + 1].ToString()}");
            }
            BiggestShape();
        }
    }
}
