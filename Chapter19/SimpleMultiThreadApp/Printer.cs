using System;
using System.Threading;

namespace SimpleMultiThreadApp
{
    public class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("-> '{0}' выполняет PrintNumbers()", Thread.CurrentThread.Name);
            Console.Write("Числа: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
