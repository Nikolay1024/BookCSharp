using System;

namespace StaticDataAndMembersApp
{
    class SavingsAccount
    {
        // Данные уровня экземпляра
        private double currBalance;
        // Данные уровня класса (Статическое поле)
        private static double currInterestRate;

        public double Balance
        {
            get { return currBalance; }
            set { currBalance = value; }
        }
        // Статическое свойство
        public static double InterestRate
        {
            get { return currInterestRate; }
            set { currInterestRate = value; }
        }

        public SavingsAccount(double balance)
        {
            Console.WriteLine("В специальном конструкторе");
            Balance = balance;
        }
        // Статический конструктор
        static SavingsAccount()
        {
            Console.WriteLine("В статическом конструкторе");
            InterestRate = 0.04;
        }

        // Статические методы
        public static void SetInterestRate(double interestRate)
        { currInterestRate = interestRate; }
        public static double GetInterestRate()
        { return currInterestRate; }
    }
}
