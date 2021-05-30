using System.Collections.Generic;

namespace GenericCollections
{
    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1?.Age > p2?.Age)
                return 1;
            else if (p1?.Age < p2?.Age)
                return -1;
            else
                return 0;
        }
    }
}
