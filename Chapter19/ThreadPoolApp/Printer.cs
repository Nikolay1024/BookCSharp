using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ThreadPoolApp
{
    [Synchronization]
    class Printer : ContextBoundObject
    {
        public void PrintNumbers()
        {
            Console.WriteLine("PrintNumbers() выполняется в потоке: {0}",
                Thread.CurrentThread.ManagedThreadId);
            Console.Write("Числа: ");
            for (int i = 0; i < 10; i++)
            {
                // Приостановить поток на случайный период времени.
                Random r = new Random();
                Thread.Sleep(1000 * r.Next(5));
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}
