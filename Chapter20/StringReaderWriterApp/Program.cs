using System;
using System.IO;
using System.Text;

namespace StringReaderWriterApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа с классами StringWriter И StringReader");
            // Создать объект StringWriter и записать символьные данные в память.
            using (StringWriter stringWriter = new StringWriter())
            {
                stringWriter.WriteLine("Строка");
                // Получить копию содержимого (хранящегося в строке) и вывести на консоль.
                Console.Write("StringWriter: {0}", stringWriter);

                // Получить внутренний объект StringBuilder.
                StringBuilder stringBuilder = stringWriter.GetStringBuilder();
                stringBuilder.Insert(0, "Привет! ");
                Console.Write("StringBuilder после Insert: {0}", stringBuilder);
                stringBuilder.Remove(0, "Привет! ".Length);
                Console.Write("StringBuilder после Remove: {0}", stringBuilder);

                using (StringReader stringReader = new StringReader(stringWriter.ToString()))
                {
                    string input = null;
                    while ((input = stringReader.ReadLine()) != null)
                        Console.WriteLine(input);
                }
            }
            Console.ReadLine();
        }
    }
}
