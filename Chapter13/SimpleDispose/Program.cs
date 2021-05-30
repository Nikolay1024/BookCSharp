using System;
using System.IO;

namespace SimpleDispose
{
    class Program
    {
        static void Main()
        {
            DisposeMethod();
            DisposeFileStream();
            UsingStatement();
            Console.ReadKey();
        }

        static void DisposeMethod()
        {
            Console.WriteLine("=> Реализация интерфейса IDisposable");
            // Создать освобождаемый объект и вызвать метод Dispose()
            // для освобождения любых внутренних ресурсов.
            MyResourceWrapper rw = new MyResourceWrapper();
            if (rw is IDisposable)
                rw.Dispose();
            Console.WriteLine();
        }
        static void DisposeFileStream()
        {
            Console.WriteLine("=> Дублирование методов в базоывых классах");
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);
            Console.WriteLine(fs.Name);
            // Вызовы этих методов делают одно и то же!
            fs.Close();
            fs.Dispose(); // Рекомедуется вызывать Dispose()
            Console.WriteLine();
        }
        static void UsingStatement()
        {
            Console.WriteLine("=> Использование оператора using для объектов IDisposable");
            // Метод Dispose() вызывается автоматически
            // при выходе за пределы области действия using.
            using (MyResourceWrapper rw1 = new MyResourceWrapper(),
                                     rw2 = new MyResourceWrapper())
            {
                // Использовать объекты MyResourceWrapper.
                Console.WriteLine(rw1.GetType().Name);
                Console.WriteLine(rw2.GetType().Name);
            }
            Console.WriteLine();
        }
    }
}