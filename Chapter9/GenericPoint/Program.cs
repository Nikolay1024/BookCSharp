using System;

namespace GenericPoint
{
    class Program
    {
        static void Main()
        {
            // Точка с координатами типа int.
            Point<int> p1 = new Point<int>(10, 10);
            Console.WriteLine(p1);
            p1.ResetPoint();
            Console.WriteLine(p1);
            Console.WriteLine();

            // Точка с координатами типа double.
            Point<double> p2 = new Point<double>(5.4, 3.3);
            Console.WriteLine(p2);
            p2.ResetPoint();
            Console.WriteLine(p2);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
