using System;

namespace FinalizableDisposableClass2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Формализованный шаблон освобождения ресурсов (Dispose() и Finalize())");
            // Вызвать метод Dispose() вручную. Это не приведет к вызову финализатора.
            MyResourceWrapper rw1 = new MyResourceWrapper();
            rw1.Dispose();
            // He вызывать метод Dispose(). Это приведет к вызову финализатора
            // и выдаче звукового сигнала.
            MyResourceWrapper rw2 = new MyResourceWrapper();
            Console.ReadKey();
        }
    }
}
