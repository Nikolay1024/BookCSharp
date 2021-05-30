using System;

namespace CarEvents
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> События");
            Car car1 = new Car("Car", 100, 10);
            // Зарегистрировать обработчики событий.
            car1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            // Групповое преобразование методов
            car1.AboutToBlow += CarAboutToBlow;
            Car.CarEngineHandler d = CarExploded;
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

        public static void CarAboutToBlow(string msg)
            => Console.WriteLine("CarAboutToBlow message: {0}", msg);
        public static void CarIsAlmostDoomed(string msg)
            => Console.WriteLine("CarIsAlmostDoomed message: {0}", msg);
        public static void CarExploded(string msg)
            => Console.WriteLine(msg);
    }
}
