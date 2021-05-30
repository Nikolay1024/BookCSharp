using System;
using System.Collections;

namespace InterfaceExtensions
{
    static class MyExtensions
    {
        public static void PrintData(this IEnumerable iterator)
        {
            foreach (var item in iterator)
                Console.WriteLine(item);
        }
    }
}
