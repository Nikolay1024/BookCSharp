using System;
using System.Collections;

namespace ComparableCar
{
    // Вспомогательный класс для сортировки массива объектов Саг по имени
    public class CarNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Car car1 && y is Car car2)
                return string.Compare(car1.Name, car2.Name);
            else
                throw new ArgumentException("Параметр не является объектом типа Car");
        }
    }
}
