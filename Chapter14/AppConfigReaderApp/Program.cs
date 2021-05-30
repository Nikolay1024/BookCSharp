using System;
using System.Configuration;

namespace AppConfigReaderApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Чтение данных файла (*.config)");
            // Извлечь специальные данные из файла *.config.
            AppSettingsReader asr = new AppSettingsReader();
            int repeatCount = (int)asr.GetValue("RepeatCount", typeof(int));
            string textColor = (string)asr.GetValue("TextColor", typeof(string));
            Console.ForegroundColor =
                (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor);
            // Вывести сообщение нужное количество раз.
            for (int i = 0; i < repeatCount; i++)
                Console.WriteLine("Сообщение!");
            Console.ReadKey();
        }
    }
}
