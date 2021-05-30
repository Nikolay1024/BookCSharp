using System;

namespace CloneablePoint2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Интерфейс ICloneable");
            Point p1 = new Point(100, 100, "Jane");
            Point p2 = (Point)p1.Clone();
            p2.Description.Name = "My new Point";
            p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.ReadKey();
        }
    }
}
