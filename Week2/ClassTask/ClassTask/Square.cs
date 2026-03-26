using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassTask
{
    internal class Square : Rectangle
    {
        public override double Height { get => base.Height; set { base.Height = value; base.Width = value; } }
        public override double Width { get => base.Width; set { base.Width = value; base.Height = value; } }
        public Square(double side, Color color, bool isHoley) : base(side, side, color, isHoley)
        {
            
        }

        public override string ToString()
        {
            string ret = $"Négyzetunk van\n{base.ToString()}";
            return ret;
        }
    }
}
