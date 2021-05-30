using System;

namespace SimpleFinalize
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Переопределение метода System.Object.Finalize()");
            MyResourceWrapper rw = new MyResourceWrapper();
            Console.WriteLine("Нажмите клавишу <Enter>, чтобы завершить приложение");
            Console.WriteLine("и заставить сборщик мусора вызвать метод Finalize()");
            Console.WriteLine("для всех финализируемых объектов, которые");
            Console.WriteLine("были созданы в домене этого приложения.");
            Console.ReadKey();
        }
    }
}
