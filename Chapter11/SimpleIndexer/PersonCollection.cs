using System.Collections;

namespace SimpleIndexer
{
    class PersonCollection : IEnumerable
    {
        private ArrayList arrPeople = new ArrayList();
        public int Count => arrPeople.Count;
        // Специальный индексатор для этого класса,
        public Person this[int index]
        {
            get => (Person)arrPeople[index];
            set => arrPeople.Insert(index, value);
        }

        // Приведение для вызывающего кода.
        public Person GetPerson(int pos) => (Person)arrPeople[pos];
        
        // Вставка только объектов Person.
        public void AddPerson(Person p) => arrPeople.Add(p);

        public void ClearPeople() => arrPeople.Clear();
        
        // Поддержка перечисления с помощью foreach.
        IEnumerator IEnumerable.GetEnumerator() => arrPeople.GetEnumerator();
    }
}
