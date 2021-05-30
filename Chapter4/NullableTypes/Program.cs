using System;

namespace NullableTypes
{
    class DatabaseReader
    {
        public int? IntValue = null;
        public bool? BoolValue = true;

        public int? GetInt()
        {
            return IntValue;
        }
        public bool? GetBool()
        {
            return BoolValue;
        }
    }

    class Program
    {
        static void Main()
        {
            LocalNullVars();
            LocalNullVarsUsingNullable();
            UseNullVars();
            UseNullCoalescingOperator();
            UseNullConditionalOperator(null);
            Console.ReadKey();
        }

        static void LocalNullVars()
        {
            int? nullInt = 10;
            double? nullDouble = 3.14;
            bool? nullBool = null;
            char? nullChar = 'a';
            int?[] arrayOfNullInts = new int?[10];
        }
        static void LocalNullVarsUsingNullable()
        {
            Nullable<int> nullInt = 10;
            Nullable<double> nullDouble = 3.14;
            Nullable<bool> nullBool = null;
            Nullable<char> nullChar = 'a';
            Nullable<int>[] arrayOfNullInts = new Nullable<int>[10];
        }

        static void UseNullVars()
        {
            Console.WriteLine("=> Типы, допускающие null");
            DatabaseReader dr = new DatabaseReader();
            int? i = dr.GetInt();
            if (i.HasValue)
                Console.WriteLine("i = {0}", i.Value);
            else
                Console.WriteLine("Значение переменной i не определено");

            bool? b = dr.GetBool();
            if (b != null)
                Console.WriteLine("b = {0}", b);
            else
                Console.WriteLine("Значение переменной b не определено");
            Console.WriteLine();
        }
        static void UseNullCoalescingOperator()
        {
            Console.WriteLine("=> Операция объединения c null");
            DatabaseReader dr = new DatabaseReader();
            int i = dr.GetInt() ?? 100;
            Console.WriteLine("dr.GetInt() ?? 100 = {0}", i);
            bool b = dr.GetBool() ?? false;
            Console.WriteLine("dr.GetBool() ?? false = {0}", b);
            Console.WriteLine();
        }
        static void UseNullConditionalOperator(string[] args)
        {
            Console.WriteLine("=> Null-условная операция");
            Console.WriteLine("Количество аргументов: {0}", args?.Length ?? 0);
            Console.WriteLine();
        }
    }
}
