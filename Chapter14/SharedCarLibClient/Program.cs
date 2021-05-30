using CarLibrary;
using System;

namespace SharedCarLibClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Потребление разделяемой сборки");
            SportsCar c = new SportsCar();
            c.TurboBoost();
            Console.ReadKey();
        }
    }
}
