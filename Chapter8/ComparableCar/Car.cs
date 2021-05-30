using System;
using System.Collections;

namespace ComparableCar
{
    class Car : IComparable
    {
        public const int MaxSpeed = 100;
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public int Speed { get; set; } = 0;
        // Свойство, возвращающее объект CarNameComparer
        public static IComparer SortByName
            => new CarNameComparer();

        public Car() { }
        public Car(int id, string name, int speed)
        {
            ID = id;
            Name = name;
            Speed = speed;
        }

        // Реализация интерфейса IComparable
#if (!true)
        int IComparable.CompareTo(object obj)
        {
            if (obj is Car car)
            {
                if (ID > car.ID)
                    return 1;
                else if (ID < car.ID)
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Параметр не является объектом типа Car");
        }
#else
        int IComparable.CompareTo(object obj)
        {
            if (obj is Car car)
                return ID.CompareTo(car.ID);
            else
                throw new ArgumentException("Параметр не является объектом типа Car");
        }
#endif
    }
}
