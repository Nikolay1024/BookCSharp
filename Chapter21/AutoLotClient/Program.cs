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

            ReadAllCars();
            ReadCar();
            DeleteCar();
            CreateCar();
            UpdateCarName();
            ReadCarName();
        }

        private static void ReadAllCars()
        {
            Console.WriteLine("-> List<Car> ReadAllCars()");
            foreach (Car car in DAL.ReadAllCars())
                Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void ReadCar()
        {
            Console.WriteLine("-> Car ReadCar(int carId)");
            Console.WriteLine(DAL.ReadCar(1));
            Console.ReadLine();
        }
        private static void DeleteCar()
        {
            try
            {
                Console.WriteLine("-> void DeleteCar(int carId)");
                int carRustyId = DAL.ReadAllCars().First(c => c.Name == "Rusty").CarId;
                DAL.DeleteCar(carRustyId);
                Console.WriteLine("Запись об автомобиле удалена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
            finally
            {
                ReadAllCars();
            }
        }
        private static void CreateCar()
        {
            Console.WriteLine("-> void CreateCar(Car car)");
            DAL.CreateCar(new Car("Rust", "Ford", "Rusty"));
            ReadAllCars();
        }
        private static void UpdateCarName()
        {
            Console.WriteLine("-> void UpdateCarName(int carId, string newCarName)");
            string newCarName = DAL.ReadCarName(1) == "Zippy" ? "NewZippy" : "Zippy";
            DAL.UpdateCarName(1, newCarName);
            ReadAllCars();
        }
        private static void ReadCarName()
        {
            Console.WriteLine("-> string ReadCarName(int carId)");
            Console.WriteLine(DAL.ReadCarName(1));
            Console.ReadLine();
        }
    }
}