﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesExercise.LSP
{
    public class Square : Shape
    {
        public int SideLength { get; set; }

        public override double TotalArea()
        {
            return SideLength * SideLength;
        }
    }
}
