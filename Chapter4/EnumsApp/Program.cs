using System;

namespace EnumsApp
{
    enum EmpType : byte
    {
        VicePresident,
        Contractor,
        Manager,
        Grunt
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Использование перечислений");
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);
            EvaluateEnum(typeof(EmpType));
            EvaluateEnum(typeof(DayOfWeek));
            EvaluateEnum(typeof(ConsoleColor));
            Console.ReadKey();
        }

        static void AskForBonus(EmpType emp)
        {
            switch (emp)
            {
                case EmpType.Manager:
                    Console.WriteLine("He желаете ли взамен фондовые опционы?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("Вы должно быть шутите...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("Вы уже получаете вполне достаточно...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("Очень хорошо, сэр!");
                    break;
            }
            Console.WriteLine();
        }

        static void EvaluateEnum(Type type)
        {
            Console.WriteLine("=> Информация о перечислении {0}", type.Name);
            Console.WriteLine("Использует для хранения значений: {0}",
                Enum.GetUnderlyingType(type));
            Array enumValues = Enum.GetValues(type);
            Console.WriteLine("Количество значений: {0}", enumValues.Length);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("|{0,20}| |{1,-20}|", "Имя", "Значение");
            Console.WriteLine("---------------------------------------------");
            foreach (var value in enumValues)
                Console.WriteLine("|{0,20}| |{0,-20:d}|", value);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
    }
}
