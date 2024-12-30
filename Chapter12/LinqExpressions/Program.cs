using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExpressions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Операции запросов LINQ");
            ProductInfo[] itemsInStock = new[]
            {
                new ProductInfo { Name = "Mac's Coffee",
                    Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo { Name = "Milk Maid Milk",
                    Description = "Milk cow's love", NumberInStock = 100},
                new ProductInfo { Name = "Pure Silk Tofu",
                    Description = "Bland as Possible", NumberInStock = 120},
                new ProductInfo { Name = "Crunchy Pops",
                    Description = "Cheezy, peppery goodness", NumberInStock = 2},
                new ProductInfo { Name = "RipOff Water",
                    Description = "From the tap to your wallet", NumberInStock = 100},
                new ProductInfo { Name = "Classic Valpo Pizza",
                    Description = "Everyone loves pizza", NumberInStock = 73}
            };
            SelectAllProducts(itemsInStock);
            SelectAllProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescriptions1(itemsInStock);
            Array objects = GetNamesAndDescriptions2(itemsInStock);
            Console.WriteLine("Имена и описание товаров (с возвратом спроецированных данных):");
            foreach (var obj in objects)
                Console.WriteLine(obj);
            Console.WriteLine();
            GetCountFromQuery(itemsInStock);
            ReverseAllProducts(itemsInStock);
            SortedNamesAndNumberInStock(itemsInStock);

            List<string> cars1 = new List<string> { "Aztec", "BMW", "Yugo" };
            List<string> cars2 = new List<string> { "Aztec", "BMW", "Saab" };
            Console.WriteLine("cars1 = {0}", string.Join(", ", cars1));
            Console.WriteLine("cars2 = {0}", string.Join(", ", cars2));
            DisplayException(cars1, cars2);
            DisplayIntersection(cars1, cars2);
            DisplayUnion(cars1, cars2);
            DisplayConcat(cars1, cars2);
            DisplayConcatNoDups(cars1, cars2);
            AggregateOps();

            LinqGrouping1();
            LinqGrouping2();
            LinqGrouping3();

            Console.ReadKey();
        }

        static void SelectAllProducts(ProductInfo[] products)
        {
            Console.WriteLine("Все товары:");
            var allProducts = from p in products select p;
            foreach (ProductInfo product in allProducts)
                Console.WriteLine(product);
            Console.WriteLine();
        }
        static void SelectAllProductNames(ProductInfo[] products)
        {
            Console.WriteLine("Все имена товаров:");
            var names = from p in products select p.Name;
            foreach (string name in names)
                Console.WriteLine(name);
            Console.WriteLine();
        }
        static void GetOverstock(ProductInfo[] products)
        {
            Console.WriteLine("Товары co складским запасом 25-100:");
            var overstock = from p in products
                            where p.NumberInStock >= 25 && p.NumberInStock <= 100
                            select p;
            foreach (ProductInfo product in overstock)
                Console.WriteLine(product);
            Console.WriteLine();
        }
        static void GetNamesAndDescriptions1(ProductInfo[] products)
        {
            Console.WriteLine("Имена и описание товаров:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
                Console.WriteLine(item);
            Console.WriteLine();
        }
        static Array GetNamesAndDescriptions2(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            // Отобразить набор анонимных объектов на объект Array.
            return nameDesc.ToArray();
        }
        static void GetCountFromQuery(ProductInfo[] products)
        {
            int count = (from p in products select p).Count();
            Console.WriteLine("{0} - количество элементов", count);
            Console.WriteLine();
        }
        static void ReverseAllProducts(ProductInfo[] products)
        {
            Console.WriteLine("Товары в обратном порядке:");
            var reversedAllProducts = (from p in products select p).Reverse();
            foreach (ProductInfo product in reversedAllProducts)
                Console.WriteLine(product);
            Console.WriteLine();
        }
        static void SortedNamesAndNumberInStock(ProductInfo[] products)
        {
            var nameNum = from p in products
                          orderby p.Name ascending
                          select new { p.Name, p.NumberInStock };
            Console.WriteLine("Имена товаров в алфавитном порядке:");
            foreach (var item in nameNum)
                Console.WriteLine(item);
            Console.WriteLine();
            nameNum = from p in products
                      orderby p.NumberInStock descending
                      select new { p.Name, p.NumberInStock };
            Console.WriteLine("Количество товаров в порядке убывания:");
            foreach (var item in nameNum)
                Console.WriteLine(item);
            Console.WriteLine();
        }

        static void DisplayException(List<string> cars1, List<string> cars2)
        {
            var carExcept = (from c in cars1 select c).Except(from c in cars2 select c);
            Console.WriteLine("Разность множеств cars1 и cars2 = {0}",
                string.Join(", ", carExcept));
        }
        static void DisplayIntersection(List<string> cars1, List<string> cars2)
        {
            var carIntersect = (from c in cars1 select c).Intersect(from c in cars2 select c);
            Console.WriteLine("Пересечение множеств cars1 и cars2 = {0}",
                string.Join(", ", carIntersect));
        }
        static void DisplayUnion(List<string> cars1, List<string> cars2)
        {
            var carUnion = (from c in cars1 select c).Union(from c in cars2 select c);
            Console.WriteLine("Объединение множеств cars1 и cars2 = {0}",
                string.Join(", ", carUnion));
        }
        static void DisplayConcat(List<string> cars1, List<string> cars2)
        {
            var carConcat = (from c in cars1 select c).Concat(from c in cars2 select c);
            Console.WriteLine("Конкатенация множеств cars1 и cars2 = {0}",
                    string.Join(", ", carConcat));
        }
        static void DisplayConcatNoDups(List<string> cars1, List<string> cars2)
        {
            var carConcat = (from c in cars1 select c).Concat(from c2 in cars2 select c2).Distinct();
            Console.WriteLine("Конкатенация множеств cars1 и cars2 без дубликатов = {0}",
                    string.Join(", ", carConcat));
            Console.WriteLine();
        }
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            Console.WriteLine("winterTemps = {0}", string.Join("; ", winterTemps));
            Console.WriteLine("Максимальная температура: {0}",
                (from t in winterTemps select t).Max());
            Console.WriteLine("Минимальная температура: {0}",
                (from t in winterTemps select t).Min());
            Console.WriteLine("Средняя температура: {0}",
                (from t in winterTemps select t).Average());
            Console.WriteLine("Сумма всех температур: {0}",
                (from t in winterTemps select t).Sum());
            Console.WriteLine();
        }

        static void LinqGrouping1()
        {
            Console.WriteLine("=> Группировка LINQ");

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
            };

            //Группировка людей по компаниям (Выражение запроса LINQ).
            //IEnumerable<IGrouping<string, Person>> peopleGroupingByCompanies =
            //    from person in people
            //    group person by person.Company;

            //Группировка людей по компаниям (Расширяющий метод LINQ).
            IEnumerable<IGrouping<string, Person>> peopleGroupingByCompanies =
                people.GroupBy(p => p.Company);

            foreach (IGrouping<string, Person> peopleGroupingByCompany in peopleGroupingByCompanies)
            {
                Console.WriteLine(peopleGroupingByCompany.Key); // Ключ - Компания.

                foreach (Person person in peopleGroupingByCompany) // Значение - Список людей в этой компании.
                    Console.WriteLine(person.Name);

                Console.WriteLine(); // Для разделения между группами.
            }
        }
        static void LinqGrouping2()
        {
            Console.WriteLine("=> Создание нового объекта при группировке LINQ");

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
            };

            // Определяет переменную iGrouping типа IGrouping<string, Person>,
            // которая будет содержать Компанию и Список людей в этой компании.
            // С помощью этой переменной мы можем затем создать новый объект анонимного типа.

            // Группировка людей по компаниям (Выражение запроса LINQ).
            //var peopleGroupingByCompanies =
            //    from person in people
            //    group person by person.Company into iGrouping
            //    select new { Company = iGrouping.Key, PeopleCount = iGrouping.Count() };

            // Группировка людей по компаниям (Расширяющий метод LINQ).
            var peopleGroupingByCompanies =
                people.GroupBy(p => p.Company).Select(g => new { Company = g.Key, PeopleCount = g.Count() });

            foreach (var company in peopleGroupingByCompanies)
                Console.WriteLine($"{company.Company} : {company.PeopleCount}");

            Console.WriteLine();
        }
        static void LinqGrouping3()
        {
            Console.WriteLine("=> Вложенный запрос LINQ");

            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
                new Person("Kate", "JetBrains"), new Person("Alice", "Microsoft"),
            };

            // Группировка людей по компаниям (Выражение запроса LINQ).
            //var peopleGroupingByCompanies =
            //    from person in people
            //    group person by person.Company into iGrouping
            //    select new
            //    {
            //        Company = iGrouping.Key,
            //        PeopleCount = iGrouping.Count(),
            //        Employees = from person in iGrouping select person, // Вложенный запрос.
            //    };

            // Группировка людей по компаниям (Расширяющий метод LINQ).
            var peopleGroupingByCompanies =
                people.GroupBy(p => p.Company).Select(g => new
                {
                    Company = g.Key,
                    PeopleCount = g.Count(),
                    Employees = g.Select(p => p),
                });

            foreach (var peopleGroupingByCompany in peopleGroupingByCompanies)
            {
                Console.WriteLine($"{peopleGroupingByCompany.Company}: {peopleGroupingByCompany.PeopleCount}");

                foreach (Person employee in peopleGroupingByCompany.Employees)
                    Console.WriteLine(employee.Name);

                Console.WriteLine(); // Для разделения компаний.
            }
        }
    }
}