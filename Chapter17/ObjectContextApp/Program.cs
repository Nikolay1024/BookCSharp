using System;

namespace ObjectContextApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Исследование контекста объекта");
            // Объекты при создании будут отображать контекстную информацию.
            SportsCar sport1 = new SportsCar();
            Console.WriteLine();
            SportsCar sport2 = new SportsCar();
            Console.WriteLine();
            SportsCarThreadSafe synchroSport = new SportsCarThreadSafe();
            Console.ReadKey();
        }
    }
}
