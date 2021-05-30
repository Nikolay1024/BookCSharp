using System;
using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Синхронный вызов делегата");
            Console.WriteLine("Main() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            // Вызвать Add() в первичном потоке.
            BinaryOp binaryOp = new BinaryOp(Add);
            // Или binaryOp.Invoke(10, 10);
            int answer = binaryOp(10, 10);
            Console.WriteLine("Продолжение Main() после завершения Add()...");
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
