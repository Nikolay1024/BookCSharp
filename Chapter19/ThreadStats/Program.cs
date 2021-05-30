using System;
using System.Threading;

namespace ThreadStats
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Статистика о текущем потоке выполнения");
            // Получить имя текущего потока.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Первичный поток";
            // Показать детали обслуживающего домена приложения и контекста.
            Console.WriteLine("Имя текущего домена приложения: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine("Идентификатор текущего контекста: {0}", Thread.CurrentContext.ContextID);
            // Вывести некоторую статистику о текущем потоке.
            Console.WriteLine("Имя потока: {0}", primaryThread.Name);
            Console.WriteLine("Поток запущен? {0}", primaryThread.IsAlive);
            Console.WriteLine("Приоритет потока: {0}", primaryThread.Priority);
            Console.WriteLine("Состояние потока: {0}", primaryThread.ThreadState);
            Console.ReadKey();
        }
    }
}
