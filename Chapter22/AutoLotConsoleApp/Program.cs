using AutoLotConsoleApp.EntityFramework;
using AutoLotConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> ADO.NET Entity Framework 6");
            CreateCar();
            CreateCars();
            UpdateCar();
            ReadCars();
            DeleteCar();
            DeleteCarWithEntityState();
            DeleteCars();

            ReadCarsMakeBMWWithSQL();
            ReadShortCarsWithSQL();

            ReadCarsMakeBMWWithLINQ();
            ReadCarsColorBlackWithLINQ();
            ReadCarsColorAndMakeWithLINQ();

            FindCarById();
            ChainingLINQQueries();

            // Lazy loading (Ленивая, отложенная загрузка)
            LazyLoading();
            // Eager loading (Энергичная, жадная, безотложная загрузка)
            EagerLoading();
            // Explicit loading (Явная загрузка)
            ExplicitLoading();
        }

        private static void CreateCar()
        {
            Console.WriteLine("--> void CreateCar(Car car)");
            using (AutoLotEntities context = new AutoLotEntities())
                try
                {
                    Car car = new Car() { Make = "Yugo", Color = "Brown", Name = "Brownie" };
                    context.Cars.Add(car);
                    EntityState entityState = context.Entry(car).State;
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
        private static void CreateCars()
        {
            Console.WriteLine("--> void CreateCars(IEnumerable<Car>)");
            List<Car> cars = new List<Car>()
            {
                new Car("Lamborghini", "Yellow", "Aventador"),
                new Car("Ferrari", "Red", "812 GTS"),
                new Car("Porsche", "White", "911")
            };
            using (AutoLotEntities context = new AutoLotEntities())
            {
                context.Cars.AddRange(cars);
                Console.WriteLine($"Добавлено { context.SaveChanges() } записи");
            }
            Console.ReadLine();
        }
        private static void ReadCars()
        {
            Console.WriteLine("--> void ReadCars()");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars)
                    Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void DeleteCar()
        {
            Console.WriteLine("--> void DeleteCar(int carId)");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                int carId = context.Cars.FirstOrDefault(c => c.Name == "Brownie").CarId;
                // Найти запись об автомобиле, подлежащую удалению, по первичному ключу.
                Car car = context.Cars.Find(carId);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    // Этот код предназначен для демонстрации того, что состояние сущности изменилось на Deleted.
                    EntityState entityState = context.Entry(car).State;
                    if (entityState != EntityState.Deleted)
                        Console.WriteLine("Невозможно удалить запись");
                    else
                        Console.WriteLine($"{ car } - EntityState:{ entityState };");
                    context.SaveChanges();
                }
            }
            Console.ReadLine();
        }
        private static void DeleteCars()
        {
            Console.WriteLine("--> void DeleteCars(IEnumerable<Car> cars)");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                List<Car> cars = context.Cars.Where(car => car.Make == "Lamborghini" || car.Make == "Ferrari").ToList();
                // Каждая запись должна быть загружена в DbChangeTracker.
                context.Cars.RemoveRange(cars);
                Console.WriteLine($"Удалено { context.SaveChanges() } записи");
            }
            Console.ReadLine();
        }
        private static void DeleteCarWithEntityState()
        {
            Console.WriteLine("void DeleteCarWithEntityState(int carId)");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                int carId = context.Cars.Where(c => c.Make == "Lamborghini").FirstOrDefault().CarId + 2;
                Car car = new Car() { CarId = carId };
                context.Entry(car).State = EntityState.Deleted;
                try
                {
                    Console.WriteLine($"Удалена { context.SaveChanges() } запись");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex);
                }
            }
            Console.ReadLine();
        }
        private static void UpdateCar()
        {
            Console.WriteLine("--> void UpdateCar(int carId)");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Найти запись об автомобиле, подлежащую обновлению, по первичному ключу.
                Car car = context.Cars.Find(1);
                if (car != null)
                {
                    EntityState entityState = context.Entry(car).State;
                    Console.WriteLine($"{ car } - EntityState:{ entityState };");
                    car.Color = car.Color == "Grey" ? "Blue" : "Grey";
                    entityState = context.Entry(car).State;
                    Console.WriteLine($"{ car } - EntityState:{ entityState };");
                    context.SaveChanges();
                }
            }
            Console.ReadLine();
        }

        private static void ReadCarsMakeBMWWithSQL()
        {
            Console.WriteLine("--> void ReadCarsMakeBMWWithSQL()");
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
        private static void ReadShortCarsWithSQL()
        {
            Console.WriteLine("--> void ReadShortCarsWithSQL()");
            // При вызове SqlQuery() на объекте Database объект DbRawSqlQuery заполняется НЕ отслеживаемыми сущностями.
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (ShortCar car in context.Database.SqlQuery(typeof(ShortCar),
                    @"SELECT car_id AS CarId,
                             make AS Make
                      FROM Inventory"))
                    Console.WriteLine(car);
            Console.ReadLine();
        }

        private static void ReadCarsMakeBMWWithLINQ()
        {
            Console.WriteLine("--> void ReadCarsMakeBMWWithLINQ()");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars.Where(car => car.Make == "BMW"))
                    Console.WriteLine(car);
            Console.ReadLine();
        }
        private static void ReadCarsColorBlackWithLINQ()
        {
            Console.WriteLine("--> void ReadCarsColorBlackWithLINQ()");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                // Получить только элементы, в которых Color == "Black".
                IEnumerable<Car> colorBlackCars = context.Cars.Where(car => car.Color == "Black");
                foreach (Car car in colorBlackCars)
                    Console.WriteLine(car);
            }
            Console.ReadLine();
        }
        private static void ReadCarsColorAndMakeWithLINQ()
        {
            Console.WriteLine("--> void ReadCarsColorAndMakeWithLINQ()");
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
                // Найти запись об автомобиле по первичному ключу.
                Console.WriteLine(context.Cars.Find(5));
            Console.ReadLine();
        }
        private static void ChainingLINQQueries()
        {
            Console.WriteLine("--> void ChainingLINQQueries()");
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

        private static void LazyLoading()
        {
            Console.WriteLine("--> void LazyLoading()");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars)
                    foreach (Order order in car.Orders)
                        Console.WriteLine(order);
            Console.ReadLine();
        }
        private static void EagerLoading()
        {
            Console.WriteLine("--> void EagerLoading()");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Car car in context.Cars.Include(c => c.Orders))
                    foreach (Order order in car.Orders)
                        Console.WriteLine(order);
            Console.ReadLine();
        }
        private static void ExplicitLoading()
        {
            Console.WriteLine("--> void ExplicitLoading()");
            using (AutoLotEntities context = new AutoLotEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                foreach (Car car in context.Cars)
                {
                    context.Entry(car).Collection(x => x.Orders).Load();
                    foreach (Order order in car.Orders)
                        Console.WriteLine(order);
                }
                foreach (Order order in context.Orders)
                    context.Entry(order).Reference(x => x.Car).Load();
            }
            Console.ReadLine();
        }
    }
}
