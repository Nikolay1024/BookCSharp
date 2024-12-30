namespace LinqExpressions
{
    class Person
    {
        public string Name { get; set; }
        public string Company { get; set; }

        public Person() { }

        public Person(string name, string company)
        {
            Name = name;
            Company = company;
        }
    }
}
