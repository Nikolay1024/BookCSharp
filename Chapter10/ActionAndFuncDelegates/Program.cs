using System;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Обобщенные делегаты Action<> и Func<>");
            // Использовать делегат Action<> для указания на DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget =
                new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message", ConsoleColor.Yellow, 5);

            // Использовать делегат Func<> для указания на Add и AddString.
            // Синтаксис групповых преобразований методов.
            Func<int, int, int> funcTarget1 = Add;
            Console.WriteLine("40 + 40 = {0}", funcTarget1(40, 40));
            Func<int, int, string> funcTarget2 = AddString;
            Console.WriteLine("90 + 300 = {0}", funcTarget2(90, 300));
            Console.ReadKey();
        }

        // Это цель для делегата Action<>.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Установить цвет текста консоли.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
                Console.WriteLine(msg);
            // Восстановить цвет.
            Console.ForegroundColor = previous;
        }
        // Цели для делегата Func<>.
        static int Add(int x, int y)
            => x + y;
        static string AddString(int x, int y)
            => (x + y).ToString();
    }
}
