using System;
using System.Threading;

namespace ThreadPoolApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Пул потоков CLR");
            Console.WriteLine("Main() выполняется в потоке: {0}",
                Thread.CurrentThread.ManagedThreadId);
            WaitCallback workItem = new WaitCallback(Print);
            Printer state = new Printer();
            // Поставить в очередь метод десять раз.
            for (int i = 0; i < 10; i++)
                ThreadPool.QueueUserWorkItem(workItem, state);
            Console.WriteLine("Все методы поставлены в очередь");
            Console.ReadKey();
        }

        static void Print(object state)
        {
            Printer p = (Printer)state;
            p.PrintNumbers();
        }
    }
}
