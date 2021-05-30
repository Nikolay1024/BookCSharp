using System;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Специальные обобщенные методы");
            // Обмен двух целочисленных значений.
            int a = 10, b = 90;
            Console.WriteLine("До: {0}, {1}", a, b);
            MyGenericMethods.Swap<int>(ref a, ref b);
            Console.WriteLine("После: {0}, {1}", a, b);
            Console.WriteLine();
            // Обмен двух строковых значений.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("До: {0} {1}", s1, s2);
            MyGenericMethods.Swap<string>(ref s1, ref s2);
            Console.WriteLine("После: {0} {1}", s1, s2);
            Console.WriteLine();

            Console.WriteLine("=> Выведение параметров типа");
            // Компилятор выведет тип System.Boolean.
            bool b1 = true, b2 = false;
            Console.WriteLine("До: {0}, {1}", b1, b2);
            MyGenericMethods.Swap(ref b1, ref b2);
            Console.WriteLine("После: {0}, {1}", b1, b2);
            Console.WriteLine();

            // Если метод не принимает параметров, то должен быть указан параметр типа.
            MyGenericMethods.DisplayBaseClass<int>();
            MyGenericMethods.DisplayBaseClass<string>();
            // Ошибка на этапе компиляции!
            // Должен быть предоставлен заполнитель!
            // DisplayBaseClass();
            Console.ReadKey();
        }
    }
}
