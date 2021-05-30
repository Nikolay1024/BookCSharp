using System;
using System.Collections;

namespace CustomEnumeratorWithYield2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Использование локальной функции");
            Garage garage = new Garage();

            // Вручную работать с IEnumerator
            IEnumerator enumerator = garage.GetEnumerator(); // Сгенерирует исключение во 2 случае
            enumerator.MoveNext(); // Сгенерирует исключение в 1 случае
            Car car = (Car)enumerator.Current;
            Console.WriteLine("{0} едет {1} км/ч", car.PetName, car.CurrentSpeed);
            Console.ReadKey();
        }
    }
}
