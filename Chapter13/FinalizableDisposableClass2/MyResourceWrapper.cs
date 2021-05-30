using System;

namespace FinalizableDisposableClass2
{
    class MyResourceWrapper : IDisposable
    {
        // Используется для выяснения, вызывался ли метод Dispose().
        private bool disposed = false;
        public void Dispose()
        {
            // Вызвать вспомогательный метод.
            // Указание true означает, что очистку
            // запустил пользователь объекта.
            Cleanup(true);
            // Подавить финализацию.
            GC.SuppressFinalize(this);
            Console.WriteLine("Вызов Dispose()");
        }

        private void Cleanup(bool disposing)
        {
            // Удостовериться, не выполнялось ли уже освобождение.
            if (!disposed)
            {
                // Если disposing равно true, тогда
                // освободить все управляемые ресурсы.
                if (disposing)
                {
                    // Освободить управляемые ресурсы.
                }
                // Очистить неуправляемые ресурсы.
            }
            disposed = true;
        }

        ~MyResourceWrapper()
        {
            // Вызвать вспомогательный метод.
            // Указание false означает, что
            // очистку запустил сборщик мусора.
            Cleanup(false);
            Console.Beep();
        }
    }
}
