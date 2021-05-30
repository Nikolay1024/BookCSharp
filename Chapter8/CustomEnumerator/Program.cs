using System;
using System.Collections;

namespace CustomEnumerator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Интерфейсы IEnumerable и IEnumerator");
            Garage garage = new Garage();
            // Проход по всем объектам Car в коллекции
            //foreach (Car car in garage)
            //    Console.WriteLine("{0} едет {1} км/ч", car.PetName, car.CurrentSpeed);

            // Вручную работать с IEnumerator
            //IEnumerator enumerator = garage.GetEnumerator();
            //enumerator.MoveNext();
            //Car car = (Car)enumerator.Current;
            //Console.WriteLine("{0} едет {1} км/ч", car.PetName, car.CurrentSpeed);
            Console.ReadKey();
        }
    }
}
