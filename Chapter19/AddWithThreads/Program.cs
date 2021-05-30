using System;
using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main()
        {
            Console.WriteLine("=> Работа с делегатом ParametrizedThreadStart");
            Console.WriteLine("Main() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            // Создать объект AddParams для передачи вторичному потоку.
            AddParams addParams = new AddParams(10, 10);
            Thread thread = new Thread(new ParameterizedThreadStart(Add));
            thread.Start(addParams);
            // Блокирует текущий поток до получения сигнала объектом AutoResetEvent!
            waitHandle.WaitOne();
            Console.WriteLine("Вторичный поток завершен!");
            Console.ReadKey();
        }

        static void Add(object obj)
        {
            if (obj is AddParams addParams)
            {
                Console.WriteLine("Add() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("{0} + {1} = {2}", addParams.A, addParams.B, addParams.A + addParams.B);
                // Сообщить другому потоку о том, что работа завершена.
                waitHandle.Set();
            }
        }

    }
}
