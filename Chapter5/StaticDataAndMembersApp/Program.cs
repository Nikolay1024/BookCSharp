using System;

namespace StaticDataAndMembersApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Статические поля и члены класса");
            Console.WriteLine("-->Работа статических методов");
            Console.WriteLine("Процентная ставка {0}", SavingsAccount.GetInterestRate());
            SavingsAccount.SetInterestRate(0.08);
            Console.WriteLine("Новая процентная ставка {0}", SavingsAccount.GetInterestRate());
            
            Console.WriteLine("-->Работа статического свойства");
            Console.WriteLine("Процентная ставка {0}", SavingsAccount.InterestRate);
            SavingsAccount.InterestRate = 0.12;
            Console.WriteLine("Новая процентная ставка {0}", SavingsAccount.InterestRate);
            Console.ReadKey();
        }
    }
}
