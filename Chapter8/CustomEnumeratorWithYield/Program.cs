using System;
using System.Collections;

namespace CustomEnumeratorWithYield
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Построение итераторных методов (yield)");
            Garage garage = new Garage();
            // Проход по всем объектам Car в коллекции
            foreach (Car car1 in garage)
                Console.WriteLine("{0} едет {1} км/ч", car1.PetName, car1.CurrentSpeed);

            // Вручную работать с IEnumerator
            IEnumerator enumerator = garage.GetEnumerator();
            enumerator.MoveNext();
            Car car2 = (Car)enumerator.Current;
            Console.WriteLine("{0} едет {1} км/ч", car2.PetName, car2.CurrentSpeed);
            Console.ReadKey();
        }
    }
}
