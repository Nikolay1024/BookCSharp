using AutoLotDataAccessLayer.DataOperations;
using AutoLotDataAccessLayer.Models;
using System;
using System.Linq;

namespace AutoLotClient
{
    class Program
    {
        private static readonly InventoryDAL DAL = new InventoryDAL();
        private static void Main()
        {
            Console.WriteLine("=> Доступ к данным с помощью ADO.NET");

            DisplayAllCars();
            Console.ReadLine();

            Console.WriteLine("-> Car GetCar(int carId)");
            Car carRusty = DAL.GetCar(DAL.GetAllCars().First(c => c.Name == "Rusty").CarId);
            Console.WriteLine(carRusty);
            Console.ReadLine();

            try
            {
                Console.WriteLine("-> void DeleteCar(int carId)");
                DAL.DeleteCar(carRusty.CarId);
                Console.WriteLine("Запись об автомобиле удалена");
                DisplayAllCars();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
                Console.ReadLine();
            }

            Console.WriteLine("-> void InsertCar(Car car)");
            DAL.InsertCar(carRusty);
            carRusty = DAL.GetAllCars().First(c => c.Name == "Rusty");
            DisplayAllCars();
            Console.ReadLine();

            Console.WriteLine("-> string GetCarName(int carId)");
            Console.WriteLine($"CarId={carRusty.CarId}; Name={DAL.GetCarName(carRusty.CarId)};");
            Console.ReadLine();
        }

        private static void DisplayAllCars()
        {
            Console.WriteLine("-> List<Car> GetAllCars()");
            foreach (Car car in DAL.GetAllCars())
                Console.WriteLine(car);
        }
    }
}