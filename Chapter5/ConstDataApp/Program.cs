using System;

namespace ConstDataApp
{
    class Program
    {
        static void Main()
        {
            ConstField();
            ConstLocalVar();
            ReadonlyField();
            ReadonlyStaticField();
            Console.ReadKey();
        }

        static void ConstField()
        {
            Console.WriteLine("=> Константные поля класса");
            Console.WriteLine("Значение PI: {0}", MyMathClass.PI);
            Console.WriteLine();
        }
        static void ConstLocalVar()
        {
            Console.WriteLine("=> Константные локальные переменные");
            const string str = "Фиксированная строка";
            Console.WriteLine(str);
            Console.WriteLine();
        }
        static void ReadonlyField()
        {
            Console.WriteLine("=> Поля только для чтения");
            MyMathClass obj = new MyMathClass();
            Console.WriteLine("Значение TAU: {0}", obj.TAU);
            Console.WriteLine();
        }
        static void ReadonlyStaticField()
        {
            Console.WriteLine("=> Статические поля только для чтения");
            Console.WriteLine("Значение E: {0}", MyMathClass.E);
            Console.WriteLine();
        }
    }
}
