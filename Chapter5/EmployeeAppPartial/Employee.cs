using System;

namespace EmployeeAppPartial
{
    partial class Employee
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
        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }
        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }
        // Методы
        public void GiveBonus(float amount)
        {
            Pay += amount;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Имя: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Зарплата: {0}", currPay);
        }
    }
}
