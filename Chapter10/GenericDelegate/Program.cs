using System;

namespace GenericDelegate
{
    class Program
    {
        // Этот обобщенный делегат может вызывать любой метод, который
        // возвращает void и принимает единственный параметр типа Т.
        public delegate void MyGenericDelegate<T>(T arg);
        static void Main()
        {
            Console.WriteLine("=> Обобщенный делегат");
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Строка");
            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9);
            Console.ReadKey();
        }

        static void StringTarget(string arg)
        {
            Console.WriteLine("arg в вверхнем регистре: {0}", arg.ToUpper());
        }
        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg = {0}", ++arg);
        }
    }
}
