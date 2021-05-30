using System;
using System.Collections;

namespace CustomEnumeratorWithYield2
{
    class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];
        // При запуске заполнить несколькими объектами Сагы
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }
#if (!true)
        // Итераторный метод
        public IEnumerator GetEnumerator()
        {
            throw new Exception("Исключение не сгенерируется, пока не будет вызван метод MoveNext()");
            foreach (Car c in carArray)
                yield return c;
        }
#else
        // Итераторный метод
        public IEnumerator GetEnumerator()
        {
            throw new Exception("Исключение сгенерируется при вызове GetEnumerator()");
            return ActualImplementation();
            // Закрытая функция
            IEnumerator ActualImplementation()
            {
                foreach (Car c in carArray)
                    yield return c;
            }
        }
#endif
    }
}
