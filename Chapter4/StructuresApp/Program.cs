using System;

namespace StructuresApp
{
    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Increment()
        {
            x++; y++;
        }
        public void Decrement()
        {
            x--; y--;
        }
        public void Display()
        {
            Console.WriteLine("x = {0}, y = {1}", x, y);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Структуры");
            Point p1;
            p1.x = 349;
            p1.y = 76;
            p1.Increment();
            p1.Display();
            Point р2 = new Point();
            Console.Write("Вызов стандартного конструктора: ");
            р2.Display();
            Point р3 = new Point(50, 60);
            Console.Write("Вызов специального конструктора: ");
            р3.Display();
            Console.ReadKey();
        }
    }
}
