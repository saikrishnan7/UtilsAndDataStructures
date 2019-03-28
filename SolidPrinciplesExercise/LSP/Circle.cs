using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.LSP
{
    public class Circle : Shape
    {
        public int Radius { get; set; }

        public override double TotalArea()
        {
            return 3.14 * Radius * Radius;
        }
    }
}
