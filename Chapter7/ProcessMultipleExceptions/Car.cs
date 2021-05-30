using System;

namespace ProcessMultipleExceptions
{
    class Car
    {
        public const int MaxSpeed = 100;
        private bool carIsDead;
        private Radio theMusicBox = new Radio();

        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        // Делегировать запрос внутреннему объекту
        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }
        // Сгенерировать специальное исключение CarIsDeadException
        public void Accelerate(int delta)
        {
            if (delta < 0)
                throw new ArgumentOutOfRangeException("delta", "Значение скорости должно быть больше нуля!");
            if (carIsDead)
                Console.WriteLine("{0} вышел из строя...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;
                    CarIsDeadException ex = new CarIsDeadException(
                        $"{PetName} перегрелся!",
                        "Слишком быстро вели машину",
                        DateTime.Now);
                    throw ex;
                }
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }

    class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Радио вкл" : "Радио выкл");
        }
    }
}
