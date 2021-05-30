using System;

namespace ObjectInitializers
{
    class Program
    {
        static void Main()
        {
            ObjectInit();
            ObjectInitAndSpecCtor();
            ObjectInitExample();
            Console.ReadKey();
        }

        static void ObjectInit()
        {
            Console.WriteLine("=> Синтаксис инициализации объектов");
            // Создать объект Point, используя свойство и поле
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 10;
            p1.DisplayStats();
            // Создать объект Point, используя специальный конструктор
            Point p2 = new Point(20, 20);
            p2.DisplayStats();
            // Создать объект Point, используя синтаксис инициализации объектов
            Point p3 = new Point() { X = 30, Y = 30 };
            p3.DisplayStats();
            Console.WriteLine();
        }
        static void ObjectInitAndSpecCtor()
        {
            Console.WriteLine("=> Синтаксис инициализации объектов и специальный конструктор");
            // Стандартный конструктор вызывается неявно
            Point p1 = new Point { X = 10, Y = 10 };
            p1.DisplayStats();
            // Стандартный конструктор вызывается явно
            Point p2 = new Point() { X = 20, Y = 20 };
            p2.DisplayStats();
            // Вызывается специальный конструктор
            Point p3 = new Point(100, 100) { X = 30, Y = 30 };
            p3.DisplayStats();
            Console.WriteLine();
        }
        static void ObjectInitExample()
        {
            Console.WriteLine("=> Применение синтаксиса инициализации");
            Rectangle myRect = new Rectangle()
            {
                TopLeft = new Point(Point.ColorType.Gold) { X = 10, Y = 10 },
                BottomRight = new Point(Point.ColorType.Gold) { X = 100, Y = 100 }
            };
            myRect.DisplayStats();
            Console.WriteLine();
        }
    }
}
