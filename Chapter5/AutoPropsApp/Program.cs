using System;

namespace AutoPropsApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Автоматические свойства");
            Console.WriteLine("-->Создать автомобиль");
            Car car = new Car();
            car.Name = "Frank";
            car.Speed = 55;
            car.Color = "Red";
            car.DisplayStats();

            Console.WriteLine("-->Поместить автомобиль в гараж");
            Garage garage = new Garage();
            garage.MyAuto = car;
            Console.WriteLine("Количество машин в гараже: {0}", garage.NumberOfCars);
            Console.WriteLine("Имя машины: {0}", garage.MyAuto.Name);
            Console.ReadKey();
        }
    }
}
