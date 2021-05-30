using System;

namespace CloneablePoint
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        // Переопределить Object.ToString()
        public override string ToString()
            => $"X = {X}; Y = {Y};";

#if (!true)
        public object Clone()
            => new Point(X, Y);
#else
        public object Clone()
            => MemberwiseClone();
#endif
    }
}
