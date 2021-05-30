using System;

namespace MethodOverloading
{
    class Program
    {
        static void Main()
        {
            Overloading();
            Console.ReadKey();
        }

        static void Overloading()
        {
            Console.WriteLine("=> Перегрузка методов");
            Console.WriteLine(Add(10, 10));
            Console.WriteLine(Add(900_000_000_000, 900_000_000_000));
            Console.WriteLine(Add(4.3, 4.4));
        }
        static int Add(int x, int y) => x + y;
        static double Add(double x, double y) => x + y;
        static long Add(long x, long y) => x + y;
    }
}
