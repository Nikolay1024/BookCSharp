using System.Collections;
using System.Collections.Generic;

namespace SimpleIndexer2
{
    class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> dictPeople = new Dictionary<string, Person>();
        public int Count => dictPeople.Count;
        // Специальный индексатор для этого класса,
        public Person this[string name]
        {
            get => dictPeople[name];
            set => dictPeople[name] = value;
        }

        public void ClearPeople() => dictPeople.Clear();
        
        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator() => dictPeople.GetEnumerator();
    }
}
