using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Reflection;

namespace LateBindingWithDynamicApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Позднее связывание с использованием 'dynamic'");
            LateBindingWithDynamic1();
            LateBindingWithDynamic2();
            Console.ReadKey();
        }

        static void LateBindingWithDynamic1()
        {
            Assembly asm = Assembly.Load("CarLibrary");
            try
            {
                // Получить метаданные для типа MiniVan.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Создать экземпляр MiniVan на лету и вызвать метод.
                dynamic obj = Activator.CreateInstance(miniVan);
                obj.TurboBoost();
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void LateBindingWithDynamic2()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Получить метаданные для типа SimpleMath.
                Type math = asm.GetType("MathLibrary.SimpleMath");
                // Создать объект SimpleMath на лету.
                dynamic obj = Activator.CreateInstance(math);
                // Обратите внимание, насколько легко теперь вызывать метод Add().
                Console.WriteLine("Результат: {0}", obj.Add(10, 70));
            }
            catch (RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
