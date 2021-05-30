using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;

namespace DynamicKeyword
{
    class Program
    {
        static void Main()
        {
            ImplicitlyTypedVariable();
            UseObjectVariable();
            PrintThreeStrings();
            ChangeDynamicDataType();
            InvokeMembersOnDynamicData();
            Console.ReadKey();
        }

        static void ImplicitlyTypedVariable()
        {
            Console.WriteLine("=> Неявная типизация переменной");
            // Переменная а имеет тип List<int>.
            var а = new List<int> { 90 };
            // Этот оператор приведет к ошибке на этапе компиляции.
            // а = "Hello";
            Console.WriteLine();
        }
        static void UseObjectVariable()
        {
            Console.WriteLine("=> Использование объектных переменных");
            object obj = new Person()
            {
                FirstName = "Mike",
                LastName = "Larson"
            };
            // Для получения доступа к свойствам Person
            // переменную obj потребуется привести к Person.
            Console.WriteLine("Имя человека: {0}\n", ((Person)obj).FirstName);
        }
        static void PrintThreeStrings()
        {
            Console.WriteLine("=> Три способа определения данных");
            var s1 = "Greetings";
            object s2 = "From";
            dynamic s3 = "Minneapolis";
            Console.WriteLine(@"Определение с 'var' : {0}", s1.GetType());
            Console.WriteLine("Определение с 'object': {0}", s2.GetType());
            Console.WriteLine("Определение с 'dynamic': {0}\n", s3.GetType());
        }
        static void ChangeDynamicDataType()
        {
            Console.WriteLine("=> Изменение типа динамической переменной");
            dynamic t = "Hello!";
            Console.WriteLine("t = {0} типа {1}", t, t.GetType());
            t = false;
            Console.WriteLine("t = {0} типа {1}", t, t.GetType());
            t = new List<int>();
            Console.WriteLine("t типа {0}\n", t.GetType());
        }
        static void InvokeMembersOnDynamicData()
        {
            Console.WriteLine("=> Вызов членов на динамически объявленных данных");
            dynamic textData = "Hello";
            try
            {
                Console.WriteLine(textData.ToUpper());
                Console.WriteLine(textData.toupper());
                Console.WriteLine(textData.Foo(10, "ее", DateTime.Now));
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
    }
}