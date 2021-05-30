using System;
using System.Threading;

namespace TypeInterlocked
{
    class Program
    {
        static int MyInt = 0;
        static void Main()
        {
            Console.WriteLine("=> Синхронизация потоков с помощью Interlocked");
            AddOne();
            SafeAssignment();
            CompareAndExchange();
            Console.ReadKey();
        }

        static void AddOne()
        {
            Interlocked.Increment(ref MyInt);
            Console.WriteLine("AddOne {0}", MyInt);
        }
        static void SafeAssignment()
        {
            Interlocked.Exchange(ref MyInt, 99);
            Console.WriteLine("SafeAssignment {0}", MyInt);
        }
        static void CompareAndExchange()
        {
            // Если значение MyInt равно 99, то изменить его на 83.
            Interlocked.CompareExchange(ref MyInt, 83, 99);
            Console.WriteLine("CompareAndExchange {0}", MyInt);
        }
    }
}
