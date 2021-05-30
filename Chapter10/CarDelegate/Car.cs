using System;

namespace CarDelegate
{
    public class Car
    {
        public int Speed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string Name { get; set; }

        private bool carIsDead;

        public Car() { }
        public Car(string name, int max, int speed)
        {
            Speed = speed;
            MaxSpeed = max;
            Name = name;
        }

        // Определить тип делегата.
        public delegate void CarEngineHandler(string msg);
        // Определить переменную-член этого типа делегата.
        private CarEngineHandler handlers;
        // Добавить регистрационный метод для вызывающего кода.
        public void RegisterWithCarEngine(CarEngineHandler method)
        {
            //handlers += method;
            handlers = (CarEngineHandler)Delegate.Combine(handlers, method);
        }
        public void UnRegisterWithCarEngine(CarEngineHandler method)
        {
            //handlers -= method;
            handlers = (CarEngineHandler)Delegate.Remove(handlers, method);
        }

        // Реализовать метод Accelerate() для обращения к списку
        // вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то отправить сообщение об этом.
            if (carIsDead && handlers != null)
                handlers("Машина сломана!");
            else
            {
                Speed += delta;
                if (Speed > MaxSpeed)
                    carIsDead = true;
                else
                {
                    Console.WriteLine("Скорость {0} км/ч", Speed);
                    if ((MaxSpeed - Speed) <= 10 && handlers != null)
                        handlers("Предельная скорость!");
                }
            }
        }
    }
}
