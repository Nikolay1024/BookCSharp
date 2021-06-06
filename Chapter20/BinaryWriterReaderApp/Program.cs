using System;
using System.IO;

namespace BinaryWriterReaderApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа С классами BinaryWriter и BinaryReader");
            // Открыть средство двоичной записи в файл.
            FileInfo fileInfo = new FileInfo("BinFile.txt");
            using (BinaryWriter binaryWriter = new BinaryWriter(fileInfo.OpenWrite()))
            {
                // Вывести на консоль тип BaseStream (FileStream в этом случае).
                Console.WriteLine("Базовый поток: {0}", binaryWriter.BaseStream);
                // Создать некоторые данные для сохранения в файле.
                double myDouble = 1234.67;
                int myInt = 34567;
                string myString = "А, В, C";
                binaryWriter.Write(myDouble);
                binaryWriter.Write(myInt);
                binaryWriter.Write(myString);
            }
            // Читать двоичные данные из потока.
            using (BinaryReader binaryReader = new BinaryReader(fileInfo.OpenRead()))
            {
                Console.WriteLine(binaryReader.ReadDouble());
                Console.WriteLine(binaryReader.ReadInt32());
                Console.WriteLine(binaryReader.ReadString());
            }
            Console.ReadLine();
        }
    }
}
