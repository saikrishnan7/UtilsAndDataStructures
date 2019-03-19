using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDataStructures
{
    public class Point : IComparable<Point>
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int val { get; private set; }

        public Point(int x, int y, int val)
        {
            this.x = x;
            this.y = y;
            this.val = val;
        }
        
        public int CompareTo(Point that)
        {
            return val.CompareTo(that.val);
        }
    }
}
