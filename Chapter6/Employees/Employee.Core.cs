namespace Employees
{
    abstract partial class Employee
    {
        // В класс Employee вложен класс BenefitPackage
        public class BenefitPackage
        {
            // В класс BenefitPackage вложено перечисление BenefitPackageLevel
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }
            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }
        // Поля данных
        protected string empName;
        protected BenefitPackage empBenefits = new BenefitPackage();
        // Конструкторы
        public Employee() { }
        public Employee(string name, int age, int id, float pay, string ssn)
        {
            Name = name;
            Age = age;
            ID = id;
            Pay = pay;
            SSN = ssn;
        }
    }
}
