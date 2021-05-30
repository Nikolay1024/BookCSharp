using System;

namespace Employees
{
    class Program
    {
        static void Main()
        {
            InheritanceHierarchy();
            AggregationDelegationInclusionModel();
            NestedTypes();
            VirtualMethods();

            CastingExamples();
            UseKeywordAs();
            UseKeywordIs();
            Console.ReadKey();
        }

        static void InheritanceHierarchy()
        {
            Console.WriteLine("=> Иерархия наследования");
            SalesPerson fred = new SalesPerson()
            {
                Age = 31,
                Name = "Fred",
                SalesNumber = 50
            };
            fred.DisplayStats();
            Console.WriteLine();
        }
        static void AggregationDelegationInclusionModel()
        {
            Console.WriteLine("=> Модель включения/делегации/агрегации");
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            chucky.DisplayStats();
            Console.WriteLine("Удержание из заработной платы: {0}", chucky.GetBenefitCost());
            Console.WriteLine();
        }
        static void NestedTypes()
        {
            Console.WriteLine("=> Вложенные типы");
            var myBenefitLevel = Employee.BenefitPackage.BenefitPackageLevel.Platinum;
            Console.WriteLine("Уровень льгот: {0}", myBenefitLevel);
            Console.WriteLine();
        }
        static void VirtualMethods()
        {
            Console.WriteLine("=> Виртуальные методы");
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
            chucky.GiveBonus(300);
            chucky.DisplayStats();
            SalesPerson fran = new SalesPerson("Fran", 43, 93, 10000, "932-32-3232", 31);
            fran.GiveBonus(200);
            fran.DisplayStats();
            Console.WriteLine();
        }

        static void CastingExamples()
        {
            Console.WriteLine("=> Приведение типов");
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            GivePromotion((Manager)frank);
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
            Console.WriteLine();
        }
        static void GivePromotion(Employee emp)
        {
            Console.WriteLine("{0} повышен!", emp.Name);
            switch (emp)
            {
                case SalesPerson sp when sp.SalesNumber > 5:
                    Console.WriteLine("{0} сделал {1} продаж!", sp.Name, sp.SalesNumber);
                    break;
                case Manager m:
                    Console.WriteLine("{0} имеет {1} опционов!", m.Name, m.StockOptions);
                    break;
            }
        }
        static void UseKeywordAs()
        {
            Console.WriteLine("=> Ключевое слово as");
            object[] things = new object[4];
            things[0] = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            things[1] = 256;
            things[2] = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            things[3] = "Строка";
            foreach (object item in things)
            {
                Employee emp = item as Employee;
                if (emp != null)
                    Console.WriteLine("Элемент {0} является работником", emp.Name);
            }
            Console.WriteLine();
        }
        static void UseKeywordIs()
        {
            Console.WriteLine("=> Ключевое слово is");
            Manager frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            GivePromotion(frank);
            PTSalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
            Console.WriteLine();
        }
    }
}
