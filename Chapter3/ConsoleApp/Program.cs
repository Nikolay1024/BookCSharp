using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Some text");
            Console.WindowHeight = 20;
            Console.WindowWidth = 100;
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.BufferHeight = 20;
            Console.BufferWidth = 100;
            Console.Title = "Console Application";

            Console.ReadKey();
        }
    }
}
