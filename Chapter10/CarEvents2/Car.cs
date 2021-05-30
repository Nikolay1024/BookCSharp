using System;

namespace CarEvents2
{
    public class CarEventArgs : EventArgs
    {
        public readonly string msg;
        public CarEventArgs(string message) => msg = message;
    }
    
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

        public delegate void CarEngineHandler(object sender, CarEventArgs e);
        // Car может отправлять следующие события:
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        public void Accelerate(int delta)
        {
            // Если автомобиль сломан, то инициировать событие Exploded.
            if (carIsDead)
                Exploded?.Invoke(this, new CarEventArgs("Машина сломана!"));
            else
            {
                Speed += delta;
                if (Speed > MaxSpeed)
                    carIsDead = true;
                else
                {
                    Console.WriteLine("Скорость {0} км/ч", Speed);
                    if (MaxSpeed - Speed <= 10)
                        AboutToBlow?.Invoke(this, new CarEventArgs("Предельная скорость!"));
                }
            }
        }
    }
}
