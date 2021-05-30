using System;

namespace CarEvents2
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

        public static void CarIsAlmostDoomed(object sender, CarEventArgs e)
        {
            if (sender is Car car)
                Console.WriteLine("Сообщение от {0}: {1}", car.Name, e.msg);
        }
        public static void CarAboutToBlow(object sender, CarEventArgs e)
            => Console.WriteLine("{0}: {1}", sender, e.msg);
        public static void CarExploded(object sender, CarEventArgs e)
            => Console.WriteLine("{0}: {1}", sender, e.msg);
    }
}
