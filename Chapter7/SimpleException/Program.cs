using System;
using System.Collections;

namespace SimpleException
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Структурированная обработка исключений");
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);
            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelerate(10);
            }
            catch (Exception e)
            {
                Console.WriteLine("-> Ошибка");
                Console.WriteLine("Имя члена: {0}", e.TargetSite);
                Console.WriteLine("Класс, определяющий член: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Тип члена: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Сообщение: {0}", e.Message);
                Console.WriteLine("Имя приложения: {0}", e.Source);
                Console.WriteLine("Стек вызовов:\n\r{0}", e.StackTrace);
                Console.WriteLine("URL-адрес справки: {0}", e.HelpLink);
                Console.WriteLine("Пользовательские данные:");
                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("   {0}: {1}", de.Key, de.Value);
            }
            Console.ReadKey();
        }
    }
}
