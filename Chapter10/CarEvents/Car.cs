using System;

namespace CarEvents
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

        public delegate void CarEngineHandler(string msg);
        // Car может отправлять следующие события:
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public void Accelerate(int delta)
        {
            // Если автомобиль сломан, то инициировать событие Exploded.
            if (carIsDead)
                Exploded?.Invoke("Машина сломана!");
            else
            {
                Speed += delta;
                if (Speed > MaxSpeed)
                    carIsDead = true;
                else
                {
                    Console.WriteLine("Скорость {0} км/ч", Speed);
                    if (MaxSpeed - Speed <= 10)
                        AboutToBlow?.Invoke("Предельная скорость!");
                }
            }
        }
    }
}
