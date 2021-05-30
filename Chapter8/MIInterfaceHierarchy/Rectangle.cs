using System;

namespace MIInterfaceHierarchy
{
    class Rectangle : IShape
    {
        // Общая реализация интерфейсов
        public void Draw()
        {
            Console.WriteLine("Рисует прямоугольник");
        }

        public void Print()
        {
            Console.WriteLine("Печатает прямоугольник");
        }

        public int GetNumberOfSides()
        {
            return 4;
        }
    }
}
