using System;

namespace ClassExampleApp
{
    class Program
    {
        static void Main()
        {
            UseConstructors();
            UseConstructorChaining();
            UseCtorWithOptionalArgs();
            Console.ReadKey();
        }

        static void UseConstructors()
        {
            Console.WriteLine("=> Работа с конструкторами");
            Car nik = new Car();
            nik.PrintState();
            Car daisy = new Car("Daisy", 75);
            daisy.PrintState();
            Car mary = new Car("Mary");
            mary.PrintState();
            Console.WriteLine();
        }
        static void UseConstructorChaining()
        {
            Console.WriteLine("=> Цепочка конструкторов с использованием this");
            Motorcycle noName = new Motorcycle(15);
            noName.PrintState();
            Motorcycle nik = new Motorcycle(25, "Nik");
            nik.PrintState();
            Console.WriteLine();
        }
        static void UseCtorWithOptionalArgs()
        {
            Console.WriteLine("=> Конструктор с необязательными аргументами");
            Bicycle noName1 = new Bicycle();
            noName1.PrintState();
            Bicycle tiny = new Bicycle(name: "Tiny");
            tiny.PrintState();
            Bicycle noName2 = new Bicycle(7);
            noName2.PrintState();
            Bicycle nik = new Bicycle(9, "Nik");
            nik.PrintState();
            Console.WriteLine();
        }
    }
}
