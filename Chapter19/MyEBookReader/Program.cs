using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyEBookReader
{
    class Program
    {
        static string eBook = string.Empty;
        static void Main()
        {
            GetBook();
            Console.ReadKey();
        }

        static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs eArgs) =>
            {
                eBook = eArgs.Result;
                Console.WriteLine("Загрузка завершена");
                GetStats();
            };
            // Загрузить электронную книгу Чарльза Диккенса "A Tale of Two Cities".
            // Может понадобиться двукратное выполнение этого кода, если ранее вы
            // не посещали данный сайт, поскольку при первом его посещении появляется
            // окно с сообщением, предотвращающее нормальное выполнение кода.
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-0.txt"));
        }
        static void GetStats()
        {
            // Получить слова из электронной книги.
            string[] words = eBook.Split(
                new char[] { ' ', '\u000A', '\u000D', ',', '.', ';', ':', '-', '!', '?', '/' },
                StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> tenMostCommon = null;
            string longestWord = string.Empty;
            Parallel.Invoke(
                () =>
                {
                    // Найти 10 наиболее часто встречающихся слов.
                    tenMostCommon = FindTenMostCommon(words);
                },
                () =>
                {
                    // Получить самое длинное слово.
                    longestWord = FindLongestWord(words);
                });
            // Когда все задачи завершены, построить строку, показывающую всю статистику в окне сообщений.
            StringBuilder bookStats = new StringBuilder("10 наиболее часто встречающихся слов:\n\r");
            foreach (KeyValuePair<string, int> pair in tenMostCommon)
                bookStats.AppendFormat("{0,5} | {1}\n\r", pair.Key, pair.Value);
            bookStats.AppendFormat("Самое длинное слово: {0}\n\r", longestWord);
            Console.Write(bookStats);
        }
        static Dictionary<string, int> FindTenMostCommon(string[] words)
        {
            var frequencyOrder =
                from word in words
                group word by word into iGrouping
                orderby iGrouping.Count() descending
                select new { Word = iGrouping.Key, Count = iGrouping.Count() };
            Dictionary<string, int> commonWords = frequencyOrder.Take(10)
                .ToDictionary(elem => elem.Word, elem => elem.Count);
            return commonWords;
        }
        static string FindLongestWord(string[] words)
        {
            return (from word in words
                    orderby word.Length descending
                    select word).FirstOrDefault();
        }
    }
}
