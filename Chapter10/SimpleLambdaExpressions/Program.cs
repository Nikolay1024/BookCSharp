using System;
using System.Collections.Generic;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main()
        {
            TraditionalDelegateSyntax();
            AnonymousMethodSyntax();
            LambdaExpressionSyntax();
            Console.ReadKey();
        }

        static void TraditionalDelegateSyntax()
        {
            Console.WriteLine("=> Использование делегатов");
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Вызвать FindAll() с применением традиционного синтаксиса делегатов.
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Четные числа:");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine();
        }
        // Цель для делегата Predicate<>.
        static bool IsEvenNumber(int i)
        {
            // Это четное число?
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            Console.WriteLine("=> Использование анонимных методов");
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Теперь использовать анонимный метод.
            List<int> evenNumbers = list.FindAll(
                delegate (int i)
                {
                    return (i % 2) == 0;
                });
            Console.WriteLine("Четные числа:");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            Console.WriteLine("=> Использование лямбда-выражений");
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Теперь использовать лямбда-выражение С#.
            // Обработать каждый аргумент внутри группы операторов кода.
            List<int> evenNumbers = list.FindAll(i =>
            {
                Console.WriteLine("Текущее значение i: {0}", i);
                bool isEven = (i % 2) == 0;
                return isEven;
            });
            Console.WriteLine("Четные числа:");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine();
        }
    }
}
