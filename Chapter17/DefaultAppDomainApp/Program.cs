using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main()
        {
            InitAppDomain();
            DisplayAppDomainStats();
            ListAsmsInAppDomain();
            Console.ReadKey();
        }

        static void InitAppDomain()
        {
            // Эта логика будет выводить имя любой сборки, загруженной
            // в домен приложения после его создания.
            AppDomain appDomain = AppDomain.CurrentDomain;
            appDomain.AssemblyLoad += (object obj, AssemblyLoadEventArgs args) =>
            {
                Console.WriteLine("Загружена сборка: {0}", args.LoadedAssembly.GetName().Name);
            };
        }
        static void DisplayAppDomainStats()
        {
            Console.WriteLine("=> Данные стандартного домена приложения");
            // Получить доступ к домену приложения для текущего потока.
            AppDomain appDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Дружественное имя: {0}", appDomain.FriendlyName);
            Console.WriteLine("Идентификатор домена в процессе: {0}", appDomain.Id);
            Console.WriteLine("Стандартный домен приложения? {0}", appDomain.IsDefaultAppDomain());
            Console.WriteLine("Базовый каталог зондирования сборок: {0}", appDomain.BaseDirectory);
            Console.WriteLine();
        }
        static void ListAsmsInAppDomain()
        {
            Console.WriteLine("=> Перечисление загруженных сборок");
            // Получить доступ к домену приложения для текущего потока.
            AppDomain appDomain = AppDomain.CurrentDomain;
            // Извлечь все сборки, загруженные в стандартный домен приложения.
            IEnumerable<Assembly> asms = from asm in appDomain.GetAssemblies()
                                         orderby asm.GetName().Name
                                         select asm;
            foreach (Assembly asm in asms)
                Console.WriteLine(asm);
            Console.WriteLine();
        }
    }
}