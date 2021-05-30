using System;
using System.Collections.Generic;

namespace InterfaceExtensions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Расширение типов, реализующих интерфейсы");
            // Array реализует IEnumerable!
            string[] data = { "Это", "массив", "строк" };
            data.PrintData();
            Console.WriteLine();
            // List<T> реализует IEnumerable!
            List<int> myInts = new List<int> { 10, 15, 20 };
            myInts.PrintData();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
