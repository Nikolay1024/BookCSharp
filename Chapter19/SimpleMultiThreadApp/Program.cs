using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа с делегатом ThreadStart");
            Console.WriteLine("Вы хотите использовать [1] или [2] потока?");
            string threadCount = Console.ReadLine();
            // Назначить имя текущему потоку.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Первичный поток";
            Console.WriteLine("-> '{0}' выполняет Main()", Thread.CurrentThread.Name);
            // Создать рабочий класс.
            Printer p = new Printer();
            switch (threadCount)
            {
                case "1":
                    p.PrintNumbers();
                    break;
                case "2":
                    // Создать поток.
                    Thread secondaryThread = new Thread(new ThreadStart(p.PrintNumbers))
                    {
                        // Теперь это фоновый поток.
                        //IsBackground = true,
                        Name = "Вторичный поток"
                    };
                    secondaryThread.Start();
                    break;
                default:
                    Console.WriteLine("Переход к варианту с одним потоком");
                    goto case "1";
            }
            MessageBox.Show("Занят!", "Выполняется работа в первичном потоке...");
            Console.ReadKey();
        }
    }
}
