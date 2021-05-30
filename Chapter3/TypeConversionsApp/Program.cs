using System;

namespace TypeConversionsApp
{
    class Program
    {
        static void Main()
        {
            TypeConversions();
            UseCheckedAndUnchecked();
            Console.ReadKey();
        }

        static void TypeConversions()
        {
            Console.WriteLine("=> Преобразование типов");
            int myInt = (int)1024L;
            Console.WriteLine("int myInt = (int)1024L = {0} (явное приведение типов)", myInt);
            double myDouble = 0.1024f;
            Console.WriteLine("double myDouble = 0.1024f = {0} (неявное приведение типов)", myDouble);
            Console.WriteLine();
        }
        static void UseCheckedAndUnchecked()
        {
            Console.WriteLine("=> Использование checked и unchecked");
            byte b1 = 100;
            byte b2 = 250;
            byte sum = (byte)Add(b1, b2);
            Console.WriteLine("(byte)Add({0}, {1}) = {2}\n\r", b1, b2, sum);

            Console.WriteLine("С checked для одного оператора:");
            try
            {
                sum = checked((byte)Add(b1, b2));
                Console.WriteLine("(byte)Add({0}, {1}) = {2}\n\r", b1, b2, sum);
            }
            catch (OverflowException ex)
            { Console.WriteLine(ex.Message + "\n\r"); }

            Console.WriteLine("С checked для блока операторов:");
            try
            {
                checked
                {
                    sum = (byte)Add(b1, b2);
                    Console.WriteLine("(byte)Add({0}, {1}) = {2}\n\r", b1, b2, sum);
                }
            }
            catch (OverflowException ex)
            { Console.WriteLine(ex.Message + "\n\r"); }

            Console.WriteLine("С unchecked для блока операторов (с установленным флагом checked для проекта:");
            unchecked
            {
                sum = (byte)Add(b1, b2);
                Console.WriteLine("(byte)Add({0}, {1}) = {2}\n\r", b1, b2, sum);
            }

        }
        static int Add(int х, int у)
        {
            return х + у;
        }
    }
}