using System;
namespace CalculatorExample
{
    // Этот класс содержит точку входа приложения.
    class Program
    {
        static void Main()
        {
            Calc c = new Calc();
            int ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is {0}.", ans);
            // Ожидать нажатия пользователем клавиши <Enter> перед завершением работы.
            Console.ReadLine();
        }
    }
    // Калькулятор С#.
    class Calc
    {
        public int Add(int x, int y)
        { return x + y; }
    }
}