using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqOverCollections
{
    class Program
    {
        static void Main()
        {
            QueryOverGenericCollection();
            QueryOverCollection();
            OfTypeAsFilter();
            Console.ReadKey();
        }

        static void QueryOverGenericCollection()
        {
            Console.WriteLine("=> Запрос LINQ к обобщенной коллекций");
            List<Car> myCars = new List<Car>
            {
                new Car { Name = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car { Name = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { Name = "Mary", Color = "Black", Speed = 55, Make = "VW" },
                new Car { Name = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car { Name = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };

            var fastCars = from c in myCars
                           where c.Speed > 90 && c.Make == "BMW"
                           select c;
            foreach (var car in fastCars)
                Console.WriteLine(car);
            Console.WriteLine();
        }
        static void QueryOverCollection()
        {
            Console.WriteLine("=> Запрос LINQ к необобщенной коллекций");
            ArrayList myCars = new ArrayList
            {
                new Car { Name = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car { Name = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car { Name = "Mary", Color = "Black", Speed = 55, Make = "VW" },
                new Car { Name = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car { Name = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };

            // Трансформировать ArrayList в тип, совместимый c IEnumerable<T>.
            IEnumerable<Car> myCarsEnum = myCars.OfType<Car>();
            var fastCars = from c in myCarsEnum
                           where c.Speed > 55
                           select c;
            foreach (var car in fastCars)
                Console.WriteLine(car);
            Console.WriteLine();
        }
        static void OfTypeAsFilter()
        {
            Console.WriteLine("=> Фильтрация данных OfТуре<T>()");
            ArrayList myObjects = new ArrayList { 10, 400, 8, false, new Car(), "Строка" };
            // Извлечь из ArrayList целочисленные значения.
            IEnumerable<int> myInts = myObjects.OfType<int>();
            foreach (int i in myInts)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
