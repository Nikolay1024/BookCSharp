namespace ObjectOverrides
{
    // Не забывайте, что класс Person расширяет Object
    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; set; } = "";

        public Person() { }
        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }

        public override string ToString()
            => $"[FirstName: {FirstName}; LastName: {LastName}; Age: {Age}]";

        #region Переопределение метода Equals() на основе сравнения свойств
        //public override bool Equals(object obj)
        //{
        //    if (!(obj is Person p))
        //        return false;
        //    return p.FirstName == FirstName
        //           && p.LastName == LastName
        //           && p.Age == Age;
        //}
        #endregion

        #region Переопределение метода Equals() на основе метода ToString()
        public override bool Equals(object obj)
            => obj?.ToString() == ToString();
        #endregion

        #region Возвратить хеш-код на основе уникальных строковых данных
        //public override int GetHashCode()
        //{
        //    return SSN.GetHashCode();
        //}
        #endregion

        #region Возвратить хеш-код на основе метода ToString()
        public override int GetHashCode()
            => ToString().GetHashCode();
        #endregion
    }
}
