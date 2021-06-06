using System;
using System.IO;
using System.Linq;

namespace StreamWriterReaderApp
{
    class Program
    {
        static void Main()
        {
            StreamWriterReader1(); // Более высокая гибкость управления чтением/записью
            StreamWriterReader2();
            Console.ReadLine();
        }

        static void StreamWriterReader1()
        {
            Console.WriteLine("=> Работа с классами StreamWriter и StreamReader");
            // Получить объект StreamWriter и записать строковые данные.
            using (StreamWriter streamWriter = File.CreateText("Message1.txt"))
            {
                streamWriter.WriteLine("Числа:");
                streamWriter.Write(string.Join(" ", Enumerable.Range(0, 10)));
                streamWriter.Write(streamWriter.NewLine);
            }
            // Прочитать данные из файла.
            Console.WriteLine("Содержимое файла Message.txt:");
            using (StreamReader streamReader = File.OpenText("Message1.txt"))
            {
                string input = null;
                while ((input = streamReader.ReadLine()) != null)
                    Console.WriteLine(input);
            }
        }
        static void StreamWriterReader2()
        {
            Console.WriteLine("=> Работа с классами StreamWriter и StreamReader");
            // Получить объект StreamWriter и записать строковые данные.
            using (StreamWriter streamWriter = new StreamWriter("Message2.txt"))
            {
                streamWriter.WriteLine("Числа:");
                streamWriter.Write(string.Join(" ", Enumerable.Range(0, 10)));
                streamWriter.Write(streamWriter.NewLine);
            }
            // Прочитать данные из файла.
            Console.WriteLine("Содержимое файла Message.txt:");
            using (StreamReader streamReader = new StreamReader("Message2.txt"))
            {
                string input = null;
                while ((input = streamReader.ReadLine()) != null)
                    Console.WriteLine(input);
            }
        }
    }
}