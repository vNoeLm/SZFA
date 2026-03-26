using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTask
{
    internal abstract class Shape
    {
        bool isHoley;
        public Color color;

        protected Shape(Color color, bool isHoley = false)
        {
            isHoley = isHoley;
            this.color = color;
        }

        public void MakeyHoley()
        {
            isHoley = true;
        }

        public abstract double Perimeter();
        public abstract double Area();

        public void MakeHoley() => isHoley = true;

        public override string ToString()
        {
            string ret = $"---------------------------------------\nAz Object szine: {this.color.ToString()}\n{(isHoley ? "Lyukas" : "Nem Lyukas")}\nTerulete: {Area()}\nKerülete: {Perimeter()}\n---------------------------------------";
            return ret;
        }


    }
}
