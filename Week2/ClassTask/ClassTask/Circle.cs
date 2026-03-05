using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    internal class Circle : Shape
    {
        public float Radius { get; set; }
        public Circle(float radius, Color color, bool isHoley) : base(color, isHoley)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
