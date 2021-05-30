using System;

namespace OverloadedOps
{
    public class Point : IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point() { }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString() => $"[{X}; {Y}]";
        public override bool Equals(object obj) => obj.ToString() == ToString();
        public override int GetHashCode() => ToString().GetHashCode();
        public int CompareTo(Point p2)
        {
            if (X > p2.X && Y > p2.Y)
                return 1;
            else if (X < p2.X && Y < p2.Y)
                return -1;
            else
                return 0;
        }

        // Перегруженные операции == и !=.
        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);
        public static bool operator !=(Point p1, Point p2) => !p1.Equals(p2);

        // Перегруженные операции <, >, <=, >=.
        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator <=(Point p1, Point p2) => p1.CompareTo(p2) <= 0;
        public static bool operator >=(Point p1, Point p2) => p1.CompareTo(p2) >= 0;

        // Перегруженные операции + и -.
        public static Point operator +(Point p1, Point p2) =>
            new Point(p1.X + p2.X, p1.Y + p2.Y);
        public static Point operator +(Point p1, int change) =>
            new Point(p1.X + change, p1.Y + change);
        public static Point operator +(int change, Point p2) =>
            new Point(p2.X + change, p2.Y + change);
        public static Point operator -(Point p1, Point p2) =>
            new Point(p1.X - p2.X, p1.Y - p2.Y);

        // Перегруженные операции ++ и --.
        public static Point operator ++(Point p1) => new Point(p1.X + 1, p1.Y + 1);
        public static Point operator --(Point p1) => new Point(p1.X - 1, p1.Y - 1);
    }
}
