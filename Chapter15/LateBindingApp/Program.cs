using System;
using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Позднее связывание");
            // Попробовать загрузить локальную копию CarLibrary.
            Assembly a;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (a != null)
                CreateUsingLateBinding(a);
            Console.ReadKey();
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа MiniVan.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Создать экземпляр MiniVan на лету.
                object obj = Activator.CreateInstance(miniVan);
                Console.Write("С использованием позднего связывания");
                Console.WriteLine(" создан объект минивэн: {0}", obj);
                // Вызвать метод TurboBoost() (null означает отсутствие аргументов).
                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                mi.Invoke(obj, null);
                // Вызвать метод TurnOnRadio() (с аргументами упакованными в массив Object).
                mi = miniVan.GetMethod("TurnOnRadio");
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
