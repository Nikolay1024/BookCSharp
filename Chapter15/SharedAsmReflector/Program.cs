using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharedAsmReflector
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Рефлексия разделяемых сборок");
            // Загрузить System.Windows.Forms.dll из GAC.
            string displayName = "System.Windows.Forms," +
                "Version=4.0.0.0," +
                "PublicKeyToken=b77a5c561934e089," +
                @"Culture=""";
            Assembly asm = Assembly.Load(displayName);
            DisplayInfo(asm);
            Console.ReadKey();
        }

        static void DisplayInfo(Assembly a)
        {
            Console.WriteLine("Имя сборки: {0}", a.GetName().Name);
            Console.WriteLine("Версия сборки: {0}", a.GetName().Version);
            Console.WriteLine("Культура сборки: {0}", a.GetName().CultureInfo.DisplayName);
            Console.WriteLine("Загружена из GAC? {0}", a.GlobalAssemblyCache);
            Console.WriteLine("\nСписок открытых перечислений:");
            Console.ReadKey();
            IEnumerable<Type> publicEnums = from pe in a.GetTypes()
                              where pe.IsEnum && pe.IsPublic
                              select pe;
            foreach (Type pe in publicEnums)
                Console.WriteLine(pe);
        }
    }
}
