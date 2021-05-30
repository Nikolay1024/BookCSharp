using System;
using System.Reflection;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Динамическая загрузка сборок");
            string asmName;
            do
            {
                Console.WriteLine("Введите абсолютный путь к сборке или Q для завершения:");
                asmName = Console.ReadLine(); // CarLibrary
                if (asmName.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    break;
                try
                {
                    Assembly asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Сборка не найдена");
                }
            } while (true);
        }

        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("-> Сборка {0}", asm.FullName);
            foreach (Type t in asm.GetTypes())
                Console.WriteLine("Тип: {0}", t);
            Console.WriteLine();
        }
    }
}
