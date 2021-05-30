using System;

namespace CustomInterface
{
    // Абстрактный базовый класс иерархии
    abstract class Shape
    {
        public string Name { get; set; }
        public Shape(string name = "NoName") => Name = name;
        public abstract void Draw();
    }

    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Рисует треугольник {0}", Name);
        }
        // Реализация IPointy
        public byte Points
        {
            get { return 3; }
        }
    }

    // Класс Circle переопределяет метод Draw().
    class Circle : Shape
    {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Рисует круг {0}", Name);
        }
    }

    // Класс Hexagon переопределяет метод Draw().
    class Hexagon : Shape, IPointy, IDraw3D
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Рисует шестиугольник {0}", Name);
        }
        // Реализация IPointy
        public byte Points
        {
            get { return 6; }
        }
        public void Draw3D()
        {
            Console.WriteLine("Рисует шестиугольник в 3D {0}", Name);
        }
    }

    // Этот класс расширяет Circle и скрывает унаследованный метод Draw()
    class ThreeDCircle : Circle, IDraw3D
    {
        // Скрыть свойство Name, определенное выше в иерархии
        public new string Name { get; set; }
        // Скрыть метод Draw(), определенный выше в иерархии
        public new void Draw()
        {
            Console.WriteLine("Рисует шар {0}", Name);
        }
        public void Draw3D()
        {
            Console.WriteLine("Рисует шар в 3D {0}", Name);
        }
    }
}
