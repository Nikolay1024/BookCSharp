using System;

namespace EmployeeApp
{
    class Employee
    {
        // Поля данных
        private string empName;
        private int empID;
        private float currPay;
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
        // Конструкторы
        public Employee() { }
        public Employee(string name, int id, float pay)
        {
            Name = name;
            ID = id;
            Pay = pay;
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
