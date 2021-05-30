namespace Employees
{
    sealed class PTSalesPerson : SalesPerson
    {
        public PTSalesPerson() { }
        public PTSalesPerson(string name, int age, int id, float pay, string ssn, int sales)
            : base(name, age, id, pay, ssn, sales)
        { }
    }
}
