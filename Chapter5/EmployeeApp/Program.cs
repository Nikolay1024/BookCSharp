using System;

namespace EmployeeApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Инкапсуляция");
            Employee emp1 = new Employee("Николай", 456, 30000);
            emp1.GiveBonus(1000);
            emp1.DisplayStats();
            emp1.Name = "Коля";
            Console.WriteLine("Имя сотрудника: {0}", emp1.Name);
            Employee emp2 = new Employee();
            emp2.Name = "Очень очень длинное имя";
            Console.ReadKey();
        }
    }
}
