using System;
using System.Reflection;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main()
        {
            ReflectAttsUsingLateBinding();
            Console.ReadKey();
        }

        static void ReflectAttsUsingLateBinding()
        {
            Console.WriteLine("=> Рефлексия атрибутов с использованием позднего связывания");
            try
            {
                // Динамическая загрузка локальной копии сборки AttributedCarLibrary.
                Assembly asm = Assembly.Load("AttributedCarLibrary");
                // Получить тип VehicleAttribute.
                Type attVehicle = asm.GetType("AttributedCarLibrary.VehicleAttribute");
                // Получить свойство Description.
                PropertyInfo propDesc = attVehicle.GetProperty("Description");
                
                // Пройти по всем типам сборки.
                foreach (Type type in asm.GetTypes())
                {
                    // Получить массив объектов VehicleAttribute для текущего типа.
                    object[] objs = type.GetCustomAttributes(attVehicle, false);
                    foreach (object obj in objs)
                        // Вывести значение свойства Description.
                        Console.WriteLine("{0}: {1}", type.Name, propDesc.GetValue(obj));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
