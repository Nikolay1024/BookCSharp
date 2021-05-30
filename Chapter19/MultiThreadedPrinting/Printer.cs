using System;
using System.Threading;

namespace MultiThreadedPrinting
{
    class Printer
    {
        // Маркер блокировки.
        private object threadLock = new object();
        public void PrintNumbers()
        {
            // Использовать в качестве маркера блокировки закрытый член object.
            lock (threadLock)
            {
                Console.WriteLine("-> '{0}' выполняет PrintNumbers()", Thread.CurrentThread.Name);
                Console.Write("Числа: ");
                for (int i = 0; i < 10; i++)
                {
                    // Приостановить поток на случайный период времени.
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }
    }
}
