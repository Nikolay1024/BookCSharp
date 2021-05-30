using System;
using System.Threading;

namespace TimeгАрр
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Программирование с использованием Timer");
            // Создать делегат для типа Timer.
            TimerCallback timerCallback = new TimerCallback(PrintTime);
            object state = "информация";
            // Установить параметры таймера.
            var _ = new Timer(
                timerCallback,  // Объект делегата TimerCallback.
                state,          // Информация для передачи в вызванный метод (null, если информация отсутствует).
                0,              // Период ожидания перед запуском (в миллисекундах).
                1000);          // Интервал между вызовами (в миллисекундах).
            Console.WriteLine("Для остановки нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Время: {0}; Параметры: {1};",
                DateTime.Now.ToLongTimeString(), state);
        }
    }
}
