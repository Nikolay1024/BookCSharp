using System;

namespace CustomException
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Строго типизированное исключение");
            Car myCar = new Car("Rusty", 90);
            try
            {
                myCar.Accelerate(50);
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Время: {0}", e.ErrorTimeStamp);
                Console.WriteLine("Причина: {0}", e.CauseOfError);
            }
            Console.ReadKey();
        }
    }
}
