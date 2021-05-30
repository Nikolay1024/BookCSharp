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

        // Итераторный метод
        public IEnumerator GetEnumerator()
        {
            foreach (Car c in carArray)
                yield return c;
        }

        // Именнованный итераторный метод
        public IEnumerable GetCars(bool reverse)
        {
            // Выполнить проверку на предмет ошибок
            return ActualImplementation();
            // Закрытая функция
            IEnumerable ActualImplementation()
            {
                if (reverse)
                    // Возвратить элементы в обратном порядке,
                    for (int i = carArray.Length; i != 0; i--)
                        yield return carArray[i - 1];
                else
                    // Возвратить элементы по порядку
                    foreach (Car с in carArray)
                        yield return с;
            }
        }
    }
}
