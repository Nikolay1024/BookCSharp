using System.Collections;

namespace CustomEnumeratorWithYield
{
    class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];
        // При запуске заполнить несколькими объектами Саг.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        // Итераторный метод
        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
                yield return c;
        }
    }
}
