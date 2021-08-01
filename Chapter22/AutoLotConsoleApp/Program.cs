using AutoLotConsoleApp.EntityFramework;
using AutoLotConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> ADO.NET Entity Framework 6");
            CreateCar();
            DisplayCars();
            DisplayCarsMakeBMW();
            DisplayShortCars();

            DisplayCarsMakeBMWWithLINQ();
            DisplayCarsColorBlackWithLINQ();
            DisplayCarsColorAndMakeWithLINQ();

            FindCarById();
            ChainingLINQQueries();
        }
        private static void CreateCar()
        {
            Console.WriteLine("--> void CreateCar()");
            using (AutoLotEntities context = new AutoLotEntities())
                try
                {
                    Car car = new Car() { Make = "Yugo", Color = "Brown", Name = "Brownie" };
                    context.Cars.Add(car);
                    EntityState entityState = context.ChangeTracker.Entries<Car>().Last().State;
                    Console.WriteLine($"{ car } - EntityState:{ entityState };");
                    context.SaveChanges();
                    Console.WriteLine($"EF заполняет поле Id значением, сгенерированным базой данных: { car.CarId }");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                }
                finally
                {
                    Console.ReadLine();
                }
        }
        private static void CreateCars(IEnumerable<Car> cars)
        {
            Console.WriteLine("--> void CreateCars(IEnumerable<Car>)");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                context.Cars.AddRange(cars);
                context.SaveChanges();
            }
        }
        private static void DisplayCars()
        {
            Console.WriteLine("--> void DisplayCars()");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars)
                    Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void DisplayCarsMakeBMW()
        {
            Console.WriteLine("--> void DisplayCarsMakeBMW()");
            // При вызове SqlQuery() на объекте DbSet<Car> объект DbSqlQuery<Car> заполняется отслеживаемыми сущностями,
            // т.е. после вызова SaveChanges() любые изменения или удаления будут переданы в базу данных.
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars.SqlQuery(
                    @"SELECT car_id AS CarId,
                            make AS Make,
                            color AS Color,
                            name as Name
                    FROM Inventory
                    WHERE make=@p0", "BMW"))
                    Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void DisplayShortCars()
        {
            Console.WriteLine("--> void DisplayShortCars()");
            // При вызове SqlQuery() на объекте Database объект DbRawSqlQuery заполняется НЕ отслеживаемыми сущностями.
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (ShortCar car in context.Database.SqlQuery(typeof(ShortCar),
                    @"SELECT car_id AS CarId,
                             make AS Make
                      FROM Inventory"))
                    Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void DisplayCarsMakeBMWWithLINQ()
        {
            Console.WriteLine("--> void DisplayCarsMakeBMWWithLINQ()");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars.Where(car => car.Make == "BMW"))
                    Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void DisplayCarsColorBlackWithLINQ()
        {
            Console.WriteLine("--> void DisplayCarsColorBlackWithLINQ()");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Получить только элементы, в которых Color == "Black".
                IEnumerable<Car> colorBlackCars = context.Cars.Where(car => car.Color == "Black");
                foreach (Car car in colorBlackCars)
                    Console.WriteLine(car);
            }
            Console.ReadLine();
        }
        private static void DisplayCarsColorAndMakeWithLINQ()
        {
            Console.WriteLine("--> void DisplayCarsColorAndMakeWithLINQ()");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Получить проекцию новых данных.
                var carColorAndMakeEnum = context.Cars.Select(car => new { car.Color, car.Make });
                foreach (var car in carColorAndMakeEnum)
                    Console.WriteLine(car);
            }
            Console.ReadLine();
        }
        private static void FindCarById()
        {
            Console.WriteLine("--> void FindCarById()");
            using (AutoLotEntities context = new AutoLotEntities())
                Console.WriteLine(context.Cars.Find(5));
            Console.ReadLine();
        }
        private static void ChainingLINQQueries()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Запрос НЕ выполняется.
                DbSet<Car> cars = context.Cars;
                // Запрос НЕ выполняется.
                var carColorAndMakeEnum = cars.Select(car => new { car.Color, car.Make });
                // Запрос выполняется.
                foreach (var car in carColorAndMakeEnum)
                    Console.WriteLine(car);
            }
            Console.ReadLine();
        }
    }
}