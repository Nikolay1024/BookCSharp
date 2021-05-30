using System;

namespace CustomInterface
{
    class Program
    {
        static void Main()
        {
            InterfaceMembers();
            TryCastToInterfaceType();
            KeywordAs();
            KeywordIs();
            PassInterfaceType();
            ReceiveInterfaceType();
            ArrayOfInterfaceType();
            Console.ReadKey();
        }

        static void InterfaceMembers()
        {
            Console.WriteLine("=> Обратиться к членам в интерфейсе IPointy");
            Hexagon h = new Hexagon();
            h.Draw();
            Console.WriteLine("Вершины: {0}", h.Points);
            Console.WriteLine();
        }
        static void TryCastToInterfaceType()
        {
            Console.WriteLine("=> Перехватить исключение InvalidCastException");
            Circle c = new Circle("Lisa");
            c.Draw();
            try
            {
                IPointy pointy = (IPointy)c;
                Console.WriteLine("Вершины: {0}", pointy.Points);
            }
            catch (InvalidCastException e)
            { Console.WriteLine(e.Message); }
            Console.WriteLine();
        }
        static void KeywordAs()
        {
            Console.WriteLine("=> Использовать ключевое слова AS");
            Hexagon h = new Hexagon("Peter");
            h.Draw();
            IPointy pointy = h as IPointy;
            if (pointy != null)
                Console.WriteLine("Вершины: {0}", pointy.Points);
            else
                Console.WriteLine("Нет вершин (не поддерживает интерфейс IPointy)");
            Console.WriteLine();
        }
        static void KeywordIs()
        {
            Console.WriteLine("=> Использовать ключевое слова IS");
            Shape[] myShapes = { new Hexagon (), new Circle (),
                new Triangle(), new ThreeDCircle()};
            for (int i = 0; i < myShapes.Length; i++)
            {
                myShapes[i].Draw();
                if (myShapes[i] is IPointy pointy)
                    Console.WriteLine("Вершины: {0}", pointy.Points);
                else
                    Console.WriteLine("Нет вершин (не поддерживает интерфейс IPointy)");
            }
            Console.WriteLine();
        }

        static void PassInterfaceType()
        {
            Console.WriteLine("=> Передача интерфейсов");
            Shape[] myShapes = { new Hexagon (), new Circle (),
                new Triangle(), new ThreeDCircle()};
            foreach (Shape s in myShapes)
                if (s is IDraw3D draw3D)
                    DrawIn3D(draw3D);
            Console.WriteLine();
        }
        static void DrawIn3D(IDraw3D draw3D)
        {
            draw3D.Draw3D();
        }

        static void ReceiveInterfaceType()
        {
            Console.WriteLine("=> Прием интерфейсов");
            Shape[] myShapes = { new Hexagon (), new Circle (),
                new Triangle(), new ThreeDCircle() };
            IPointy pointy = FindFirstPointyShape(myShapes);
            Console.WriteLine("Первая фигура с вершинами имеет {0} вершин", pointy?.Points);
            Console.WriteLine();
        }
        static IPointy FindFirstPointyShape(Shape[] myShapes)
        {
            foreach (Shape s in myShapes)
                if (s is IPointy pointy)
                    return pointy;
            return null;
        }

        static void ArrayOfInterfaceType()
        {
            Console.WriteLine("=> Массив интерфейсов");
            IPointy[] myPointyObjects = { new Hexagon(), new Triangle() };
            foreach (IPointy pointy in myPointyObjects)
                Console.WriteLine("Объект {0} имеет {1} вершин",
                    pointy.GetType().Name, pointy.Points);
            Console.WriteLine();
        }
    }
}
