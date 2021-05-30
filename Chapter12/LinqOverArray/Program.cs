using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqOverArray
{
    class Program
    {
        static void Main()
        {
            QueryOverStrings();
            QueryOverStringsWithExtensionMethods();
            QueryOverInts();
            DeferredQueryExecution();
            ImmediateQueryExecution();
            Console.ReadKey();
        }

        static void QueryOverStrings()
        {
            Console.WriteLine("=> LINQ to Objects (Выражения запросов LINQ)");
            string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Запрос для нахождения элементов массива,
            // которые содержат пробелы,
            // отсортированных в алфовитном порядке.
            IEnumerable<string> subset = from game in games
                                         where game.Contains(" ")
                                         orderby game
                                         select game;

            ReflectOverQueryResults(subset, "Выражение запроса");
            foreach (string game in subset)
                Console.WriteLine(game);
            Console.WriteLine();
        }
        static void QueryOverStringsWithExtensionMethods()
        {
            Console.WriteLine("=> LINQ to Objects (Расширяющие методы LINQ)");
            string[] games = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Запрос для нахождения элементов массива,
            // которые содержат пробелы,
            // отсортированных в алфовитном порядке.
            IEnumerable<string> subset = games
                .Where(game => game.Contains(" "))
                .OrderBy(game => game)
                .Select(game => game);

            ReflectOverQueryResults(subset, "Расширяющие методы");
            foreach (string game in subset)
                Console.WriteLine(game);
            Console.WriteLine();
        }
        static void ReflectOverQueryResults(object result, string query)
        {
            Console.WriteLine("Формат запроса LINQ: {0}", query);
            Console.WriteLine("Тип результата: {0}", result.GetType().Name);
            Console.WriteLine("Сборка, содержащая тип: {0}", result.GetType().Assembly.GetName().Name);
        }
        static void QueryOverInts()
        {
            Console.WriteLine("=> LINQ и неявно типизированные локальные переменные");
            int[] nums = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Выбрать только элементы меньше 10.
            // Используется неявная типизация.
            var subset = from i in nums where i < 10 select i;
            ReflectOverQueryResults(subset, "Выражение запроса");
            foreach (var i in subset)
                Console.Write(i + " ");
            Console.WriteLine("\n");
        }
        static void DeferredQueryExecution()
        {
            Console.WriteLine("=> Отложенное выполнение запроса LINQ");
            int[] nums = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subset = from i in nums where i < 10 select i;
            // Оператор LINQ здесь оценивается!
            foreach (var i in subset)
                Console.Write(i + " ");
            Console.WriteLine();
            nums[0] = 4;
            // Снова производится оценка!
            foreach (var i in subset)
                Console.Write(i + " ");
            Console.WriteLine("\n");
        }
        static void ImmediateQueryExecution()
        {
            Console.WriteLine("=> Немедленное выполнение запроса LINQ");
            int[] nums = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Получить данные НЕМЕДЛЕННО как int[].
            int[] subsetArrayInts = (from i in nums where i < 10 select i).ToArray();
            // Получить данные НЕМЕДЛЕННО как List<int>.
            List<int> subsetListInts = (from i in nums where i < 10 select i).ToList();
            nums[0] = 4;
            Console.WriteLine(string.Join(" ", subsetArrayInts));
            Console.WriteLine(string.Join(" ", subsetListInts));
            Console.WriteLine();
        }
    }
}
