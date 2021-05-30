using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqRetValues
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Возвращение результатов запроса LINQ");
            IEnumerable<string> subset1 = GetStringSubset();
            foreach (string item in subset1)
                Console.WriteLine(item);
            Console.WriteLine();

            string[] subset2 = GetStringSubsetAsArray();
            foreach (string item in subset2)
                Console.WriteLine(item);
            Console.ReadKey();
        }

        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            // Обратите внимание, что subset является
            // совместимым с IEnumerable<string> объектом.
            IEnumerable<string> redColors = from c in colors
                                            where c.Contains("Red")
                                            select c;
            return redColors;
        }
        static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var redColors = from c in colors
                            where c.Contains("Red")
                            select c;
            // Отобразить результаты в массив.
            return redColors.ToArray();
        }
    }
}
