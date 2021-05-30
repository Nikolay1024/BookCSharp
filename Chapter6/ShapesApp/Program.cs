using System;

namespace ShapesApp
{
    class Program
    {
        static void Main()
        {
            AbstractMembers();
            HideMembers();
            Console.ReadKey();
        }

        static void AbstractMembers()
        {
            Console.WriteLine("=> Абстрактные члены (полиморфный интерфейс)");
            Shape[] myShapes = { new Hexagon(), new Circle (),
                new Hexagon("Mick"), new Circle("Beth"), new Hexagon("Linda") };
            // Взаимодействие с полиморфным интерфейсом
            foreach (Shape shape in myShapes)
                shape.Draw();
            Console.WriteLine();
        }
        static void HideMembers()
        {
            Console.WriteLine("=> Сокрытие членов");
            // Здесь вызывается метод Draw(), определенный в классе ThreeDCircle
            ThreeDCircle sphere = new ThreeDCircle();
            sphere.Draw();
            // Здесь вызывается метод Draw(), определенный в родительском классе
            ((Circle)sphere).Draw();
            Console.WriteLine();
        }
    }
}
