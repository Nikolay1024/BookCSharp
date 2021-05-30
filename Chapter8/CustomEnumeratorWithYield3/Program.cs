using System;

namespace CustomEnumeratorWithYield2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Именованные итераторы");
            Garage garage = new Garage();
            
            // Получить элементы, используя GetEnumerator()
            foreach (Car car in garage)
                Console.WriteLine("{0} едет {1} км/ч", car.PetName, car.CurrentSpeed);
            Console.WriteLine();
            // Получить элементы в обратном порядке, используя именованный итератор
            foreach (Car car in garage.GetCars(true))
                Console.WriteLine("{0} едет {1} км/ч", car.PetName, car.CurrentSpeed);

            Console.ReadKey();
        }
    }
}
