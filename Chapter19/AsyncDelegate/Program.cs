using System;
using System.Threading;

namespace AsyncDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Асинхронный вызов делегата");
            Console.WriteLine("Main() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            // Вызвать Add() во вторичном потоке.
            BinaryOp binaryOp = new BinaryOp(Add);
            IAsyncResult iAsyncResult = binaryOp.BeginInvoke(10, 10, null, null);
            Console.WriteLine("Одновременное выполнение Main() в первичном и Add() во вторичном потоке");
            Console.WriteLine("Ожидание завершения Add()...");
            int answer = binaryOp.EndInvoke(iAsyncResult);
            Console.WriteLine("10 + 10 = {0}", answer);
            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
