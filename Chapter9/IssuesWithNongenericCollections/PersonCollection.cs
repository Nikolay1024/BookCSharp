using System.Collections;

namespace IssuesWithNongenericCollections
{
    class PersonCollection : IEnumerable
    {
        private ArrayList arrPeople = new ArrayList();
        public int Count => arrPeople.Count;

        // Приведение для вызывающего кода.
        public Person GetPerson(int pos) => (Person)arrPeople[pos];
        
        // Вставка только объектов Person.
        public void AddPerson(Person p) => arrPeople.Add(p);

        public void ClearPeople() => arrPeople.Clear();
        
        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator() => arrPeople.GetEnumerator();
    }
}
