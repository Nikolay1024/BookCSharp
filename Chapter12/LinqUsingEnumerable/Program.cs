using System;
using System.Linq;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main()
        {
            QueryWithOperators();
            QueryWithEnumerableAndLambdas();
            QueryWithEnumerableAndAnonMethods();
            QueryWithEnumerableAndRawDelegates();
            Console.ReadKey();
        }

        static void QueryWithOperators()
        {
            Console.WriteLine("=> Использование операции запросов LINQ");
            string[] games = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};
            var subset = from g in games
                         where g.Contains(" ")
                         orderby g
                         select g;
            foreach (string g in subset)
                Console.WriteLine(g);
            Console.WriteLine();
        }
        static void QueryWithEnumerableAndLambdas()
        {
            Console.WriteLine("=> Использование типа Enumerable и лямбда-выражений");
            string[] games = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};
            // Построить выражение запроса с использованием расширяющих методов,
            // предоставленных типу Array через тип Enumerable.
            var subset = games
                .Where(g => g.Contains(" "))
                .OrderBy(g => g)
                .Select(g => g);
            foreach (var g in subset)
                Console.WriteLine(g);
            Console.WriteLine();
        }
        static void QueryWithEnumerableAndAnonMethods()
        {
            Console.WriteLine("=> Использование типа Enumerable и анонимных методов");
            string[] games = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};
            // Построить необходимые делегаты Func<> с использованием анонимных методов.
            Func<string, bool> searchFilter =
                delegate (string g) { return g.Contains(" "); };
            Func<string, string> itemToProcess =
                delegate (string g) { return g; };
            // Передать делегаты в методы класса Enumerable.
            var subset = games
                .Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);
            foreach (var g in subset)
                Console.WriteLine(g);
            Console.WriteLine();
        }
        static void QueryWithEnumerableAndRawDelegates()
        {
            Console.WriteLine("=> Использование типа Enumerable и низкоуровневых делегатов");
            string[] games = {"Morrowind", "Uncharted 2",
                "Fallout 3", "Daxter", "System Shock 2"};
            // Построить необходимые делегаты Func<>.
            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);
            // Передать делегаты в методы класса Enumerable.
            var subset = games
                .Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);
            foreach (var g in subset)
                Console.WriteLine(g);
            Console.WriteLine();
        }
        // Цели делегатов.
        static bool Filter(string game)
        {
            return game.Contains(" ");
        }
        static string ProcessItem(string game)
        {
            return game;
        }
    }
}
