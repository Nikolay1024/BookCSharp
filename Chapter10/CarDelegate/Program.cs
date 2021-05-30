using System;

namespace CarDelegate
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Уведомление о состоянии объекта с использованием делегатов");
            Car car1 = new Car("Car", 100, 10);
            // Сообщить объекту Car, какой метод вызывать,
            // когда он пожелает отправить сообщение.
            car1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent1));
            // Сохранить объект делегата, чтобы позже можно было отменить регистрацию.
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            car1.RegisterWithCarEngine(handler2);
            // Увеличить скорость (это инициирует события).
            for (int i = 0; i < 6; i++)
                car1.Accelerate(20);
            Console.WriteLine();
            // Отменить регистрацию второго обработчика.
            car1.UnRegisterWithCarEngine(handler2);
            // Сообщения в верхнем регистре больше не выводятся.
            car1.Accelerate(20);
            Console.ReadKey();
        }

        // Цель для входящих сообщении.
        static void OnCarEngineEvent1(string msg)
        {
            Console.WriteLine("***** Сообщение из объекта Car *****");
            Console.WriteLine("***** {0} *****", msg);
        }
        static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("===== {0} =====", msg.ToUpper());
        }
    }
}
