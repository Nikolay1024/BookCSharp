using System;

namespace AnonymousTypes
{
    class Program
    {
        static void Main()
        {
            BuildAnonType("BMW", "Black", 90);
            EqualityTest();
            NestedAnonType();
            Console.ReadKey();
        }

        static void BuildAnonType(string make, string color, int speed)
        {
            Console.WriteLine("=> Анонимные типы");
            // Построить анонимный тип с применением входных аргументов.
            var car = new { Make = make, Color = color, Speed = speed };
            // Этот тип можно использовать для получения данных свойств.
            Console.WriteLine("{0} {1} едет {2} км/ч", car.Color, car.Make, car.Speed);
            // Анонимные типы имеют специальные реализации каждого
            // виртуального метода System.Object.
            ReflectOverAnonType(car);
            Console.WriteLine();
        }
        static void EqualityTest()
        {
            Console.WriteLine("=> Эквивалентность анонимных типов");
            // Создать два анонимных класса с идентичными наборами пар "имя-значение".
            var car1 = new { Color = "Bright Pink", Make = "Saab", Speed = 55 };
            var car2 = new { Color = "Bright Pink", Make = "Saab", Speed = 55 };
            // Отобразить все детали.
            ReflectOverAnonType(car1);
            Console.WriteLine();
            ReflectOverAnonType(car2);
            Console.WriteLine();
            Console.WriteLine("car1.Equals(car2) = {0}", car1.Equals(car2));
            Console.WriteLine("car1 == car2 = {0}", car1 == car2);
            Console.WriteLine("car1.GetType().Name == car2.GetType().Name = {0}",
                car1.GetType().Name == car2.GetType().Name);
            Console.WriteLine();
        }
        static void NestedAnonType()
        {
            Console.WriteLine("=> Вложенные анонимные типы");
            var purchase = new
            {
                Time = DateTime.Now,
                Item = new { Color = "Red", Make = "Saab", MaxSpeed = 80 },
                Price = 34000
            };
            ReflectOverAnonType(purchase);
        }
        static void ReflectOverAnonType(object obj)
        {
            Console.WriteLine("GetHashCode() = {0}", obj.GetHashCode());
            Console.WriteLine("ToString() = {0}", obj.ToString());
            Console.WriteLine("GetType().Name = {0}", obj.GetType().Name);
            Console.WriteLine("GetType().BaseType = {0}", obj.GetType().BaseType);
        }
    }
}
