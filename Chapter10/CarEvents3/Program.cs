using System;

namespace CarEvents3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> События");
            Car car1 = new Car("Car", 100, 10);
            // Привязаться к событиям с помощью лямбда-выражений.
            car1.AboutToBlow += (sender, e) =>
            {
                if (sender is Car car)
                    Console.WriteLine("Сообщение от {0}: {1}", car.Name, e.msg);
            };
            car1.AboutToBlow += (sender, e) => Console.WriteLine("{0}: {1}", sender, e.msg);
            Car.CarEngineHandler d = (sender, e) => Console.WriteLine("{0}: {1}", sender, e.msg);
            car1.Exploded += d;
            // Увеличить скорость (это инициирует события).
            for (int i = 0; i < 6; i++)
                car1.Accelerate(20);
            Console.WriteLine();
            // Удалить метод CarExploded из списка вызовов.
            car1.Exploded -= d;
            car1.Accelerate(20);
            Console.ReadKey();
        }
    }
}
