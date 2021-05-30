using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Роль делегата AsyncCallback");
            Console.WriteLine("Main() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            // Вызвать Add() во вторичном потоке.
            BinaryOp binaryOp = new BinaryOp(Add);
            IAsyncResult iAsyncResult = binaryOp.BeginInvoke(
                10, 10, new AsyncCallback(AddComplete), "String state");
            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            // Сделать паузу для моделирования длительной операции.
            Thread.Sleep(5000);
            return x + y;
        }

        static void AddComplete(IAsyncResult iAsyncResult)
        {
            Console.WriteLine("AddComplete() вызван в потоке: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Сумма посчитана");
            // Теперь получить результат.
            AsyncResult asyncResult = (AsyncResult)iAsyncResult;
            BinaryOp binaryOp = (BinaryOp)asyncResult.AsyncDelegate;
            Console.WriteLine("10 + 10 = {0}", binaryOp.EndInvoke(iAsyncResult));
            // Получить информационный объект и привести его к типу string,
            string msg = (string)iAsyncResult.AsyncState;
            Console.WriteLine(msg);
        }
    }
}
