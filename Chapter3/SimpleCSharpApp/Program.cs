using System;

namespace SimpleCSharpApp
{
    class Program
    {
        static int Main(string[] args)
        {
            // Получить аргументы с использованием System.Environment.
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine("Arg: {0}", arg);
            Console.ReadLine();

            return -1;
        }
    }
}
