using System;

namespace CustomEnumeratorWithYield
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
        // Генерировать исключение, если пользователь превышает MaxSpeed
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0} вышел из строя...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;
                    // Мы хотим обращаться к свойству HelpLink, поэтому необходимо
                    // создать локальную переменную перед генерацией объекта Exception
                    Exception ex = new Exception($"{PetName} перегрелся!");
                    ex.HelpLink = "http://www.PegasusCars.com";
                    // Предоставить специальные данные, касающиеся ошибки.
                    ex.Data.Add("TimeStamp", $"Машина взорвалась в {DateTime.Now}");
                    ex.Data.Add("Cause", "Слишком быстро вели машину");
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
