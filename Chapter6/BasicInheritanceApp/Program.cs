using System;

namespace BasicInheritanceApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Базовое наследование");
            Car myCar = new Car(max: 80) { Speed = 50 };
            Console.WriteLine("Моя машина едет {0} км/ч", myCar.Speed);
            Minivan myVan = new Minivan() { Speed = 10 };
            Console.WriteLine("Мой минивэн едет {0} км/ч", myVan.Speed);
            Console.ReadKey();
        }
    }
}
