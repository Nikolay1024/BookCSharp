using System;

namespace SimpleDelegate
{
    // Этот делегат может указывать на любой метод, который принимает
    // два целочисленных значения и возвращает целочисленное значение.
    public delegate int BinaryOp(int x, int y);
    // Этот класс содержит методы, на которые
    // будет указывать BinaryOp.
    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Sub(int x, int y) => x - y;
        public static int SquareNumber(int a) => a * a;
        public int Mul(int x, int y) => x * y;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Делегат");
            // Создать объект делегата BinaryOp, который
            // "указывает" на SimpleMath.Add().
            BinaryOp b1 = new BinaryOp(SimpleMath.Add);
            // Вызвать метод Add() косвенно с использованием объекта делегата.
            // Здесь неявно вызывается метод Invoke()
            Console.WriteLine("10 + 10 = {0}", b1(10, 10));
            // Здесь явно вызывается метод Invoke()
            Console.WriteLine("20 + 20 = {0}", b1.Invoke(20, 20));

            // Ошибка на этапе компиляции!
            // Метод не соответствует шаблону делегата.
            //BinaryOp b2 = new BinaryOp(SimpleMath.SquareNumber);

            BinaryOp b3 = new BinaryOp(new SimpleMath().Mul);
            DisplayDelegateInfo(b1);
            DisplayDelegateInfo(b3);
            Console.ReadKey();
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            // Вывести имена всех членов в списке вызовов делегата.
            foreach (Delegate d in delObj.GetInvocationList())
            {
                Console.WriteLine("Имя метода: {0}", d.Method);
                Console.WriteLine("Имя типа: {0}", d.Target ?? "null");
            }
        }
    }
}
