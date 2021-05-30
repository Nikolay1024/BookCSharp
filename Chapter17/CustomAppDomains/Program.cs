using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomAppDomains
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Создание новых доменов приложений");
            DefaultAppDomain();
            MakeNewAppDomain();
            Console.ReadKey();
        }

        static void DefaultAppDomain()
        {
            AppDomain defaultAppDomain = AppDomain.CurrentDomain;
            defaultAppDomain.ProcessExit += (object obj, EventArgs args) =>
            {
                Console.WriteLine("Стандартный домен приложения выгружен");
            };
            ListAsmsInAppDomain(defaultAppDomain);
        }
        static void MakeNewAppDomain()
        {
            AppDomain appDomain = AppDomain.CreateDomain("SecondAppDomain");
            appDomain.DomainUnload += (object obj, EventArgs args) =>
            {
                Console.WriteLine("Второй домен приложения выгружен");
            };
            try
            {
                // Загрузить CarLibrary.dll в этот новый домен.
                appDomain.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            ListAsmsInAppDomain(appDomain);
            // Выгрузить домен приложения.
            AppDomain.Unload(appDomain);
        }
        static void ListAsmsInAppDomain(AppDomain appDomain)
        {
            // Получить все сборки, загруженные в домен приложения.
            IEnumerable<Assembly> asms = from asm in appDomain.GetAssemblies()
                                         orderby asm.GetName().Name
                                         select asm;
            Console.WriteLine("Сборки загруженные в домен {0}:", appDomain.FriendlyName);
            foreach (Assembly asm in asms)
                Console.WriteLine(asm);
            Console.WriteLine();
        }
    }
}
