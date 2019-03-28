using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.LSP
{
    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public override double TotalArea()
        {
            return Height * Width;
        }
    }
}
