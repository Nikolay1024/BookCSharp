using System;

namespace AutoPropsApp
{
    class Car
    {
        // Автоматические свойства! Нет нужды определять поддерживающие поля
        public string Name { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        public void DisplayStats()
        {
            Console.WriteLine("Имя машины: {0}", Name);
            Console.WriteLine("Скорость: {0}", Speed);
            Console.WriteLine("Цвет: {0}", Color);
        }
    }
}
