using CarLibrary;
using System;

namespace CodeBaseClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Элемент <codeBase>");
            SportsCar c = new SportsCar();
            Console.WriteLine("Был создан объект SportsCar");
            Console.ReadKey();
        }
    }
}
