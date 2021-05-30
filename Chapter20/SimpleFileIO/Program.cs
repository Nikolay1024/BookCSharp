using System;
using System.IO;

namespace SimpleFileIO
{
    class Program
    {
        static void Main()
        {
            Directory.CreateDirectory("FileInfo");
            // Возвращают FileStream.
            FileInfoCreate();
            FileInfoCreateWithUsing();
            FileInfoOpen();
            FileInfoOpenRead();
            FileInfoOpenWrite();
            // Возвращают StreamReader.
            FileInfoOpenText();
            FileInfoCreateText();
            FileInfoAppendText();

            Directory.CreateDirectory("File");
            FileWriteAllLines();
            FileReadAllLines();
            Console.ReadKey();
        }

        static void FileInfoCreate()
        {
            // Создать новый файл.
            FileInfo file = new FileInfo(@"FileInfo\Create");
            FileStream fs = file.Create();
            // Использовать объект FileStream...
            // Закрыть файловый поток.
            fs.Close();
        }
        static void FileInfoCreateWithUsing()
        {
            // Определение блока using для типов файлового ввода-вывода.
            FileInfo file = new FileInfo(@"FileInfo\CreateWithUsing");
            using (FileStream fs = file.Create())
            {
                // Использовать объект FileStream...
            }
        }
        static void FileInfoOpen()
        {
            // Создать новый файл посредством Open().
            FileInfo file = new FileInfo(@"FileInfo\Open");
            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                // Использовать объект FileStream...
            }
        }
        static void FileInfoOpenRead()
        {
            // Получить объект FileStream с правами только для чтения.
            FileInfo file = new FileInfo(@"FileInfo\OpenRead");
            file.Create().Close();
            using (FileStream fs = file.OpenRead())
            {
                // Использовать объект FileStream...
            }
        }
        static void FileInfoOpenWrite()
        {
            // Получить объект FileStream с правами только для записи.
            FileInfo file = new FileInfo(@"FileInfo\OpenWrite");
            using (FileStream fs = file.OpenWrite())
            {
                // Использовать объект FileStream...
            }
        }

        static void FileInfoCreateText()
        {
            FileInfo file = new FileInfo(@"FileInfo\CreateText.txt");
            using (StreamWriter sr = file.CreateText())
            {
                // Использовать объект StreamWriter...
            }
        }
        static void FileInfoAppendText()
        {
            FileInfo file = new FileInfo(@"FileInfo\AppendText.txt");
            using (StreamWriter sr = file.AppendText())
            {
                // Использовать объект StreamWriter...
            }
        }
        static void FileInfoOpenText()
        {
            // Получить объект StreamReader.
            FileInfo file = new FileInfo(@"FileInfo\OpenText.txt");
            file.Create().Close();
            using (StreamReader sr = file.OpenText())
            {
                // Использовать объект StreamReader...
            }
        }
        
        static void FileWriteAllLines()
        {
            string[] arrStr = { "Write", "All", "Lines" };
            // Записать все данные в файл.
            File.WriteAllLines(@"File\WriteAllLines.txt", arrStr);
        }
        static void FileReadAllLines()
        {
            // Прочитать все данные и вывести на консоль.
            foreach (string str in File.ReadAllLines(@"File\WriteAllLines.txt"))
                Console.WriteLine(str);
        }
    }
}