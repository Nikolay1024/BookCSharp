using System;

namespace CloneablePoint
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Интерфейс ICloneable");
            // Две ссылки на один и тот же объект
            Point p1 = new Point(50, 50);
            Point p2 = p1;
            p2.X = 0;
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine();

            // Обратите внимание, что Clone() возвращает простой тип object
            // Для получения производного типа требуется явное приведение
            Point pЗ = new Point(100, 100);
            Point p4 = (Point)pЗ.Clone();
            p4.X = 0;
            Console.WriteLine(pЗ);
            Console.WriteLine(p4);
            Console.ReadKey();
        }
    }
}
