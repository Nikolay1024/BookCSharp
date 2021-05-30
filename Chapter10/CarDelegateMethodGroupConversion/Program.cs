using System;

namespace CarDelegateMethodGroupConversion
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Синтаксис групповых преобразований методов");
            Car car1 = new Car("Car", 100, 10);
            // Зарегистрировать простое имя метода.
            car1.RegisterWithCarEngine(OnCarEngineEvent);
            // Увеличить скорость (это инициирует события).
            for (int i = 0; i < 6; i++)
                car1.Accelerate(20);
            Console.WriteLine();
            // Отменить регистрацию простого имени метода.
            car1.UnRegisterWithCarEngine(OnCarEngineEvent);
            // Уведомления больше не поступают!
            car1.Accelerate(20);
            Console.ReadKey();
        }

        // Цель для входящих сообщении.
        static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("***** Сообщение из объекта Car *****");
            Console.WriteLine("***** {0} *****", msg);
        }
    }
}
