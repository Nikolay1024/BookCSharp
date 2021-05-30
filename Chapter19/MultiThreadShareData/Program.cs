using System;
using System.Threading;

namespace MultiThreadShareData
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Синхронизация потоков с помощью типа Monitor");
            Printer p = new Printer();
            // Создать 10 потоков, которые выполняют одновременно
            // один и тот же метод одного и того же объекта.
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers));
                threads[i].Name = $"Вторичный поток {i}";
            }
            // Теперь запустить все потоки.
            foreach (Thread t in threads)
                t.Start();
            Console.ReadKey();
        }
    }
}