using AttributedCarLibrary;
using System;

namespace VehicleDescriptionAttributeReader
{
    class Program
    {
        static void Main()
        {
            ReflectOnAttsUsingEarlyBinding();
            Console.ReadKey();
        }

        static void ReflectOnAttsUsingEarlyBinding()
        {
            Console.WriteLine("=> Рефлексия атрибутов с использованием раннего связывания");
            // Получить объект Type, представляющий тип Winnebago.
            Type t = typeof(Winnebago);
            // Получить все атрибуты Winnebago.
            object[] atts = t.GetCustomAttributes(false);
            foreach (VehicleAttribute v in atts)
                Console.WriteLine("Атрибут: {0}", v.Description);
        }
    }
}
