using System;

namespace Employees
{
    class Manager : Employee
    {
        public int StockOptions { get; set; }

        public Manager() { }
        public Manager(string name, int age, int id, float pay, string ssn, int numOfOpt)
            : base(name, age, id, pay, ssn)
        {
            StockOptions = numOfOpt;
        }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Количество фондовых опционов: {0}", StockOptions);
        }
    }
}
