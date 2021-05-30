using System;

namespace ClassExampleApp
{
    class Car
    {
        public string Name;
        public int Speed;

        // Переопределенный стандартный конструктор
        public Car() => Name = "Nik";

        // Перегрузка специального конструктора
        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        // Специальный конструктор сжатый до выражения
        // Поле Speed получает стандартное значение для int (0)
        public Car(string name) => Name = name;

        public void PrintState()
            => Console.WriteLine("{0} едет на машине со скоростью {1} км/ч.", Name, Speed);

        public void SpeedUp(int delta)
            => Speed += delta;
    }
}
