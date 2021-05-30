using System;

namespace OverloadedOps
{
    class Program
    {
        static void Main()
        {
            OverloadBinaryOps();
            ImplicitOverloadOpsCompoundAssignment();
            OverloadUnaryOps();
            OverloadEquivalenceOps();
            OverloadComparisonOps();
            Console.ReadKey();
        }

        static void OverloadBinaryOps()
        {
            Console.WriteLine("=> Перегрузка бинарных операций");
            Point p1 = new Point(100, 100);
            Point p2 = new Point(40, 40);
            Console.WriteLine("p1 = {0}", p1);
            Console.WriteLine("p2 = {0}", p2);
            // Сложить две точки.
            Console.WriteLine("p1 + p2 = {0}", p1 + p2);
            // Вычесть одну точку из другой.
            Console.WriteLine("p1 - p2 = {0}", p1 - p2);
            // Сложить точки с целочисленным литералом.
            Console.WriteLine("p1 + 10 = {0}", p1 + 10);
            Console.WriteLine("10 + p2 = {0}", 10 + p2);
            Console.WriteLine();
        }
        static void ImplicitOverloadOpsCompoundAssignment()
        {
            Console.WriteLine("=> Неявная перегрузка операций составных присваиваний");
            Point p1 = new Point(100, 100);
            Point p2 = new Point(40, 40);
            // Операция += перегружена автоматически.
            Console.WriteLine("p1 += p2; p1 = {0}", p1 += p2);
            // Операция -= перегружена автоматически.
            Console.WriteLine("p1 -= p2; p1 = {0}", p1 -= p2);
            Console.WriteLine();
        }
        static void OverloadUnaryOps()
        {
            Console.WriteLine("=> Перегрузка унарных операций");
            // Применение унарных операций ++ и -- к объекту Point
            // в виде префиксного инкремента/декремента.
            Point p1 = new Point(100, 100);
            Console.WriteLine("++p1 = {0}", ++p1);
            Console.WriteLine("--p1 = {0}", --p1);
            // Применение унарных операций ++ и -- к объекту Point
            // в виде постфиксного инкремента/декремента.
            Point p2 = new Point(40, 40);
            Console.WriteLine("p2++ = {0}", p2++);
            Console.WriteLine("p2-- = {0}", p2--);
            Console.WriteLine();
        }
        static void OverloadEquivalenceOps()
        {
            Console.WriteLine("=> Перегрузка операций эквивалентности");
            Point p1 = new Point(100, 100);
            Point p2 = new Point(40, 40);
            Console.WriteLine("p1 == p2: {0}", p1 == p2);
            Console.WriteLine("p1 != p2: {0}", p1 != p2);
        }
        static void OverloadComparisonOps()
        {
            Console.WriteLine("=> Перегрузка операций сравнения");
            Point p1 = new Point(100, 100);
            Point p2 = new Point(40, 40);
            Console.WriteLine("p1 < p2 : {0}", p1 < p2);
            Console.WriteLine("p1 > p2 : {0}", p1 > p2);
        }
    }
}
