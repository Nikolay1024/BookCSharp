using System;

namespace CustomGenericMethods
{
    class MyGenericMethods
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine(typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }
        public static void DisplayBaseClass<T>()
        {
            // BaseType - метод, используемый в рефлексии.
            Console.WriteLine("Базовым классом {0} является: {1}", typeof(T), typeof(T).BaseType);
        }
    }
}
