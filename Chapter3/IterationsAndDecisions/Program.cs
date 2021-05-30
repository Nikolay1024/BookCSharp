using System;

namespace IterationsAndDecisions
{
    class Program
    {
        static void Main()
        {
            ForLoopExample();
            ForEachLoopExample();
            WhileLoopExample();
            DoWhileLoopExample();
            IfElseExample();
            IfElseConditionalOperator();
            SwitchExample();
            SwitchEnumExample();
            SwitchPatternMatching();
            Console.ReadKey();
        }

        static void ForLoopExample()
        {
            for (int i = 0; i < 4; i++)
                Console.WriteLine("Текущее число: {0} ", i);
            Console.WriteLine();
        }

        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Yugo", "Honda" };
            foreach (string carType in carTypes)
                Console.WriteLine(carType);
            Console.WriteLine();
        }

        static void WhileLoopExample()
        {
            string userIsDone = "";
            while (userIsDone != "1")
            {
                Console.WriteLine("В цикле while");
                Console.Write("Выйти из цикла? 1 [да] 2 [нет]: ");
                userIsDone = Console.ReadLine();
            }
            Console.WriteLine();
        }

        static void DoWhileLoopExample()
        {
            string userIsDone = "";
            do
            {
                Console.WriteLine("В цикле do/while");
                Console.Write("Выйти из цикла? 1 [да] 2 [нет]: ");
                userIsDone = Console.ReadLine();
            } while (userIsDone != "1");
            Console.WriteLine();
        }

        static void IfElseExample()
        {
            string stringData = "Строка";
            if (stringData.Length > 0)
                Console.WriteLine("Строка больше 0 символов");
            else
                Console.WriteLine("Строка меньше 0 символов");
            Console.WriteLine();
        }

        static void IfElseConditionalOperator()
        {
            string stringData = "Строка";
            Console.WriteLine(stringData.Length > 0
            ? "Строка больше 0 символов"
            : "Строка меньше 0 символов");
            Console.WriteLine();
        }

        static void SwitchExample()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Выберите предпочитаемый язык: ");
            int n = int.Parse(Console.ReadLine());
            // Стандартный оператор switch, в котором
            // применяется сопоставление образца с константой
            switch (n)
            {
                case 1:
                    Console.WriteLine("Хороший выбор. C# - замечательный язык.");
                    break;
                case 2:
                    Console.WriteLine("VB: ООП, многопоточность и многое другое!");
                    break;
                default:
                    Console.WriteLine("Хорошо, удачи с этим!");
                    break;
            }
            Console.WriteLine();
        }

        static void SwitchEnumExample()
        {
            Console.Write("Введите любимый день недели: ");
            DayOfWeek favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            switch (favDay)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("{0} - будний день.", favDay);
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("{0} - выходной день.", favDay);
                    break;
            }
            Console.WriteLine();
        }

        static void SwitchPatternMatching()
        {
            Console.WriteLine("1 [Int (5)], 2 [Double (2.5)], 3 [String (\"Привет\")]");
            Console.Write("Выбери переменную: ");
            int userChoice = int.Parse(Console.ReadLine());
            object choice;
            switch (userChoice)
            {
                case 1:
                    choice = 5;
                    break;
                case 2:
                    choice = 2.5;
                    break;
                case 3:
                    choice = "Привет";
                    break;
                default:
                    choice = 5;
                    break;
            }
            // Новый оператор switch, в котором применяется
            // сопоставление образца с типом и константой
            switch (choice)
            {
                case int i when i == 5:
                    Console.WriteLine("Выбрано целое число {0}.", i);
                    break;
                case double d when d == 2.5:
                    Console.WriteLine("Выбрано дробное число {0}.", d);
                    break;
                case string s when s == "Привет":
                    Console.WriteLine("Выбрана строка \"{0}\".", s);
                    break;
                default:
                    Console.WriteLine("Выбрано что-то другое.");
                    break;
            }
            Console.WriteLine();
        }
    }
}
