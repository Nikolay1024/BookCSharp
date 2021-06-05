using System;
using System.IO;
using System.Text;

namespace FileStreamApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа с классом FileStream");
            // Получить объект FileStream.
            using (FileStream fileStream = File.Open("Message.txt", FileMode.Create))
            {
                string msg = "Hello!";
                Console.WriteLine("Исходное сообщение: {0}", msg);

                // Закодировать строку в byte[].
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                // Записать byte[] в файл.
                fileStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                
                // Сбросить внутреннюю позицию потока.
                fileStream.Position = 0;

                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                // Прочитать byte[] из файла.
                fileStream.Read(bytesFromFile, 0, msgAsByteArray.Length);
                Console.Write("Ваше сообщение как массив байтов: ");
                Console.WriteLine(string.Join(" ", bytesFromFile));

                Console.Write("Декодированное сообщение: ");
                // Декодировать строку из byte[].
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadLine();
        }
    }
}
