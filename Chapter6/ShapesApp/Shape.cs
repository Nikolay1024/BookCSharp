using System;

namespace ShapesApp
{
    // Абстрактный базовый класс иерархии
    abstract class Shape
    {
        public string Name { get; set; }
        public Shape(string name = "NoName") => Name = name;

        public abstract void Draw();
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
    class Hexagon : Shape
    {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void Draw()
        {
            Console.WriteLine("Рисует шестиугольник {0}", Name);
        }
    }
    
    // Этот класс расширяет Circle и скрывает унаследованный метод Draw()
    class ThreeDCircle : Circle
    {
        // Скрыть свойство Name, определенное выше в иерархии
        public new string Name { get; set; }
        // Скрыть любую реализацию Draw(), находящуюся выше в иерархии
        public new void Draw()
        {
            Console.WriteLine("Рисует шар {0}", Name);
        }
    }
}
