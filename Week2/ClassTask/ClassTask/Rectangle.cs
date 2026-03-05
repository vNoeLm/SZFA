using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    internal class Rectangle : Shape
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public Rectangle(double width, double height, Color color, bool isHoley) : base(color, isHoley)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            string ret = $"Téglalapunk van\n{base.ToString()}";
            return ret;
        }

        public override double Area()
        {
            return Width * Height;
        }
        public override double Perimeter()
        {
            return 2 * Width + 2 * Height;
        }
    }
}
