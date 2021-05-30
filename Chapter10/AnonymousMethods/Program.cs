using System;

namespace AnonymousMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Анонимные методы");
            Car car1 = new Car("Car", 100, 10);
            int aboutToBlowCounter = 0;
            // Зарегистрировать обработчики событий как анонимные методы.
            car1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Сообщение");
            };
            car1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                if (sender is Car car)
                    Console.WriteLine("Сообщение от {0}: {1}", car.Name, e.msg);
            };
            Car.CarEngineHandler d = delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("{0}: {1}", sender, e.msg);
            };
            car1.Exploded += d;
            // Увеличить скорость (это инициирует события).
            for (int i = 0; i < 6; i++)
                car1.Accelerate(20);
            // Удалить метод из списка вызовов.
            car1.Exploded -= d;
            car1.Accelerate(20);
            Console.WriteLine("aboutToBlowCounter = {0}", aboutToBlowCounter);
            Console.ReadKey();
        }
    }
}
