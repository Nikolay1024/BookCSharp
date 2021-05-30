using System.Collections;

namespace IssuesWithNongenericCollections
{
    class IntCollection : IEnumerable
    {
        private ArrayList arrInts = new ArrayList();
        public int Count => arrInts.Count;

        // Получение int (выполняется распаковка) .
        public int Getlnt(int pos) => (int)arrInts[pos];

        // Вставка int (выполняется упаковка).
        public void Addlnt(int i) => arrInts.Add(i);

        public void Clearlnts() => arrInts.Clear();

        IEnumerator IEnumerable.GetEnumerator() => arrInts.GetEnumerator();
    }
}
