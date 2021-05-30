using CarLibrary;
using System;

namespace CSharpCarClient
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Построение клиентского приложения C#");
            // Создать объект SportsCar.
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();
            // Создать объект MiniVan.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();
            Console.ReadKey();
        }
    }
}
