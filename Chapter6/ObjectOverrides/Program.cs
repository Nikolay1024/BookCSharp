using System;

namespace ObjectOverrides
{
    class Program
    {
        static void Main()
        {
            OverriddenMembers();
            StaticMembers();
            Console.ReadKey();
        }

        static void OverriddenMembers()
        {
            Console.WriteLine("=> Переопределяемые члены System.Object");
            Person p1 = new Person("Homer", "Simpson", 50);
            Person p2 = new Person("Homer", "Simpson", 50);
            // Тестирование методов ToString(), Equals() и GetHashCode().
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2? {0}", p1.Equals(p2));
            Console.WriteLine("Одинаковые хэш-коды? {0}",
                p1.GetHashCode() == p2.GetHashCode());
            Console.WriteLine();
            // Изменить возраст p2 и протестировать снова.
            p2.Age = 45;
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = р2? {0}", p1.Equals(p2));
            Console.WriteLine("Одинаковые хэш-коды? {0}",
                p1.GetHashCode() == p2.GetHashCode());
            Console.WriteLine();
        }
        static void StaticMembers()
        {
            Console.WriteLine("=> Статические члены System.Object");
            Person p3 = new Person("Sally", "Jones", 4);
            Person p4 = new Person("Sally", "Jones", 4);
            Console.WriteLine("p3 и p4 имеют одинаковое состояние? {0}",
                object.Equals(p3, p4));
            Console.WriteLine("p3 и p4 указывают на один объект в памяти? {0}",
                object.ReferenceEquals(p3, p4));
            Console.WriteLine();
        }
    }
}
