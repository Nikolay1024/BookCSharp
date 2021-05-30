using System;
using static UtilityClassApp.TimeUtilClass;

namespace UtilityClassApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Статический (служебный) класс");
            PrintDate();
            PrintTime();
            Console.ReadKey();
        }
    }
}
