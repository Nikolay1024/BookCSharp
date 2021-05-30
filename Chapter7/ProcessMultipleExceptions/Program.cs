using System;

namespace ProcessMultipleExceptions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Обработка множества исключений");
            Car myCar = new Car("Rusty", 90);
            myCar.CrankTunes(true);
            try
            {
                myCar.Accelerate(90);
            }
            catch (CarIsDeadException e) when (e.ErrorTimeStamp.DayOfWeek == DayOfWeek.Thursday)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Время: {0}", e.ErrorTimeStamp);
                Console.WriteLine("Причина: {0}", e.CauseOfError);
                Console.WriteLine("Сегодня четверг");
            }
            catch (CarIsDeadException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Время: {0}", e.ErrorTimeStamp);
                Console.WriteLine("Причина: {0}", e.CauseOfError);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            // Этот блок будет перехватывать все остальные исключения
            // помимо CarIsDeadException и ArgumentOutOfRangeException
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // Это код будет выполняться всегда независимо
            // от того, возникало исключение или нет
            finally
            {
                myCar.CrankTunes(false);
            }
            Console.ReadKey();
        }
    }
}
