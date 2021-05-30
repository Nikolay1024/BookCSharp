using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDataProcessingWithCancellation
{
    class Program
    {
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Для выполнения запроса нажмите любую клавишу...");
                Console.ReadKey();
                Console.WriteLine("Запрос...");
                Task.Factory.StartNew(() => ProcessIntData());
                Console.Write("Введите Q для выхода: ");
                string answer = Console.ReadLine();
                if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    cancelTokenSource.Cancel();
                    break;
                }
            }
            Console.ReadKey();
        }

        static void ProcessIntData()
        {
            // Получить очень большой массив целых чисел.
            int[] source = Enumerable.Range(1, 100_000_000).ToArray();
            int[] modThreeIsZero = null;
            try
            {
                // Найти числа, для которых истинно условие num % 3 == О, и возвратить их в убывающем порядке.
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelTokenSource.Token)
                                  where num % 3 == 0
                                  orderby num descending
                                  select num).ToArray();
                // Вывести количество найденных чисел.
                Console.WriteLine("\n\rНайдено {0} чисел, соответствующих запросу", modThreeIsZero.Count());
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
