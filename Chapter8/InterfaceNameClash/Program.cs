using System;

namespace InterfaceNameClash
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Явная реализация интерфейсов");
            Octagon octagon = new Octagon();
            // Для доступа к явно реализованным членам интерфейса
            // Draw() нужно использовать приведение типов
            IDrawToForm drawToForm = octagon;
            drawToForm.Draw();
            // Сокращенная форма, если переменная интерфейса не нужна
            ((IDrawToPrinter)octagon).Draw();
            // Можно также использовать ключевое слово is.
            if (octagon is IDrawToMemory drawToMemory)
                drawToMemory.Draw();
            Console.ReadKey();
        }
    }
}
