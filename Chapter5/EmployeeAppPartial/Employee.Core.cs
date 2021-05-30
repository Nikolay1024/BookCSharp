namespace EmployeeAppPartial
{
    partial class Employee
    {
        // Поля данных
        private string empName;
        private int empID;
        private float currPay;
        // Конструкторы
        public Employee() { }
        public Employee(string name, int id, float pay)
        {
            Name = name;
            ID = id;
            Pay = pay;
        }
    }
}
