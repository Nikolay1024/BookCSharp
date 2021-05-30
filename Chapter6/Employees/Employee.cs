using System;

namespace Employees
{
    abstract partial class Employee
    {
        // Свойства
        public string Name
        {
            get { return empName; }
            set
            {
                if (value.Length > 15)
                    Console.WriteLine("Ошибка! Длина имени превышает 15 символов!");
                else
                    empName = value;
            }
        }
        // Открывает доступ к объекту через специальное свойство
        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }
        public int Age { get; set; }
        public int ID { get; set; }
        public float Pay { get; set; }
        public string SSN { get; }
        // Методы
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }
        public virtual void DisplayStats()
        {
            Console.WriteLine("Имя: {0}", Name);
            Console.WriteLine("Возраст: {0}", Age);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Зарплата: {0}", Pay);
            Console.WriteLine("Номер социального страхования: {0}", SSN);
        }
        // Открывает доступ к некоторому поведению, связанному со льготами
        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }
    }
}
