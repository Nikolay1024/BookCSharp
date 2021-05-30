using System;

namespace MIInterfaceHierarchy
{
    class Square : IShape
    {
        // Явная реализация интерфейса
        void IDrawable.Draw()
        {
            Console.WriteLine("Вывести на экран квадрат");
        }

        // Явная реализация интерфейса
        void IPrintable.Draw()
        {
            Console.WriteLine("Вывести на принтер квадрат");
        }

        public void Print()
        {
            Console.WriteLine("Печатает квадрат");
        }

        public int GetNumberOfSides()
        {
            return 4;
        }
    }
}
