using System;

namespace ValueAndReferenceTypes
{
    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
    class PointRef
    {
        public int X;
        public int Y;

        public PointRef(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Display()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }

    class ShapeInfo
    {
        public string Info;
        public ShapeInfo(string info)
        {
            Info = info;
        }
    }
    struct Rectangle
    {
        public ShapeInfo ShapeInfo;
        public int Top, Left, Bottom, Right;
        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            ShapeInfo = new ShapeInfo(info);
            Top = top; Bottom = bottom; Left = left; Right = right;
        }
        public void Display()
        {
            Console.WriteLine("ShapeInfo = {0}, Top = {1}, Bottom = {2}, Left = {3}, Right = {4}",
                ShapeInfo.Info, Top, Bottom, Left, Right);
        }
    }

    class Program
    {
        static void Main()
        {
            ValueTypeAssignment();
            ReferenceTypeAssignment();
            ValTypeContainingRefType();
            Console.ReadKey();
        }

        static void ValueTypeAssignment()
        {
            Console.WriteLine("=> Присваивание типов значений");
            Point p1 = new Point(10, 10);
            Point p2 = p1;
            p1.Display();
            p2.Display();
            p1.X = 100;
            Console.WriteLine("-> Изменение p1 не затронуло p2");
            p1.Display();
            p2.Display();
            Console.WriteLine();
        }
        static void ReferenceTypeAssignment()
        {
            Console.WriteLine("=> Присваивание ссылочных типов");
            PointRef p1 = new PointRef(10, 10);
            PointRef p2 = p1;
            p1.Display();
            p2.Display();
            p1.X = 100;
            Console.WriteLine("-> Изменение p1 затронуло p2");
            p1.Display();
            p2.Display();
            Console.WriteLine();
        }
        
        static void ValTypeContainingRefType()
        {
            Console.WriteLine("=> Присваивание типов значений, содержащих ссылочные типы");
            Rectangle r1 = new Rectangle("Прямоугольник", 10, 10, 10, 10);
            Rectangle r2 = r1;
            r1.Display();
            r2.Display();
            Console.WriteLine("-> Изменение r1");
            r1.ShapeInfo.Info = "Измененный";
            r1.Top = 100;
            r1.Display();
            r2.Display();
            Console.WriteLine();
        }
    }
}
