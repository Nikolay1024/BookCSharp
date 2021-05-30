using System;

namespace TuplesApp
{
    class Program
    {
        static void Main()
        {
            TupleDeclaration();
            TuplePropNames();
            InferredTuplePropNames();

            TupleOutputParam();
            TupleDeconstruction();
            TupleDiscard();

            Console.ReadKey();
        }

        static void TupleDeclaration()
        {
            Console.WriteLine("=> Объявление кортежей");
            (string, int, char) tuple1 = ("a", 5, 'c');
            var tuple2 = ("a", 5, 'c');
            Console.WriteLine("tuple1.Item1 = {0}", tuple1.Item1);
            Console.WriteLine("tuple1.Item2 = {0}", tuple1.Item2);
            Console.WriteLine("tuple1.Item3 = {0}", tuple1.Item3);
            Console.WriteLine();
        }       
        static void TuplePropNames()
        {
            Console.WriteLine("=> Установка имен свойств кортежей");
            (string myStr, int myInt, char myChar) tuple1 = ("a", 5, 'c');
            string myStr = "a";
            var tuple2 = (myStr, myInt: 5, 'c');
            Console.WriteLine("tuple3.myStr = tuple3.Item1 = {0}", tuple2.myStr);
            Console.WriteLine("tuple3.myInt = tuple3.Item2 = {0}", tuple2.myInt);
            Console.WriteLine("tuple3.Item3 = {0}", tuple2.Item3);
            Console.WriteLine();
        }        
        static void InferredTuplePropNames()
        {
            Console.WriteLine("=> Выведение имен свойств кортежей");
            var foo = new { prop1 = "first", prop2 = "second" };
            var tuple = (foo.prop1, foo.prop2);
            Console.WriteLine("{0} = {1}", nameof(tuple.prop1), tuple.prop1);
            Console.WriteLine("{0} = {1}", nameof(tuple.prop2), tuple.prop2);
            Console.WriteLine();
        }
        
        static void TupleOutputParam()
        {
            Console.WriteLine("=> Кортеж как выходной параметр");
            var tuple = ReceiveTuple();
            Console.WriteLine("tuple.myInt = {0}", tuple.myInt);
            Console.WriteLine("tuple.myStr = {0}", tuple.myStr);
            Console.WriteLine("tuple.myBool = {0}", tuple.myBool);
            Console.WriteLine();
        }       
        static void TupleDeconstruction()
        {
            Console.WriteLine("=> Деконструирование кортежей");
            (int myInt1, string myStr1, bool myBool1) = ReceiveTuple();
            var (myInt2, myStr2, myBool2) = ReceiveTuple();
            Console.WriteLine("myInt = {0}", myInt2);
            Console.WriteLine("myStr = {0}", myStr2);
            Console.WriteLine("myBool = {0}", myBool2);
            Console.WriteLine();
        }
        static void TupleDiscard()
        {
            Console.WriteLine("=> Отбрасывание с кортежами");
            var (_, _, myBool) = ReceiveTuple();
            Console.WriteLine("myBool = {0}", myBool);
            Console.WriteLine();
        }
        static (int myInt, string myStr, bool myBool) ReceiveTuple()
        {
            return (9, "Строка", true);
        }
    }
}
