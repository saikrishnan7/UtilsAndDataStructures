using System;

namespace ComplexDataStructures
{
    public class Point : IComparable<Point>
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Val { get; private set; }

        public Point(int x, int y, int val)
        {
            this.X = x;
            this.Y = y;
            this.Val = val;
        }
        
        public int CompareTo(Point that)
        {
            return Val.CompareTo(that.Val);
        }
    }
}
