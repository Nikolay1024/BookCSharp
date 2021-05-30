using System;

namespace ComparableCar
{
    class Program
    {
        static void Main()
        {
            TestIComparable();
            TestIComparer();
            TestIComparerWithProp();
            Console.ReadKey();
        }

        static void TestIComparable()
        {
            Console.WriteLine("=> Интерфейс IComparable");
            Car[] cars = new Car[5];
            cars[0] = new Car(1, "Rusty", 80);
            cars[1] = new Car(234, "Mary", 40);
            cars[2] = new Car(34, "Viper", 40);
            cars[3] = new Car(4, "Mel", 40);
            cars[4] = new Car(5, "Chucky", 40);
            // Отсортировать массив по ID
            Array.Sort(cars);
            foreach (Car car in cars)
                Console.WriteLine("{0} {1}", car.ID, car.Name);
            Console.WriteLine();
        }
        static void TestIComparer()
        {
            Console.WriteLine("=> Интерфейс IComparer");
            Car[] cars = new Car[5];
            cars[0] = new Car(1, "Rusty", 80);
            cars[1] = new Car(234, "Mary", 40);
            cars[2] = new Car(34, "Viper", 40);
            cars[3] = new Car(4, "Mel", 40);
            cars[4] = new Car(5, "Chucky", 40);
            // Отсортировать массив по Name
            Array.Sort(cars, new CarNameComparer());
            foreach (Car car in cars)
                Console.WriteLine("{0} {1}", car.Name, car.ID);
            Console.WriteLine();
        }
        static void TestIComparerWithProp()
        {
            Console.WriteLine("=> Интерфейс IComparer и специальное свойство");
            Car[] cars = new Car[5];
            cars[0] = new Car(1, "Rusty", 80);
            cars[1] = new Car(234, "Mary", 40);
            cars[2] = new Car(34, "Viper", 40);
            cars[3] = new Car(4, "Mel", 40);
            cars[4] = new Car(5, "Chucky", 40);
            // Отсортировать массив по Name
            Array.Sort(cars, Car.SortByName);
            foreach (Car car in cars)
                Console.WriteLine("{0} {1}", car.Name, car.ID);
            Console.WriteLine();
        }
    }
}
