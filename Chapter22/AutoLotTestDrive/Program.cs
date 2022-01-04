using AutoLotDataAccessLayer.EntityFramework;
using AutoLotDataAccessLayer.Models;
using AutoLotDataAccessLayer.Repos;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            //Database.SetInitializer(new MyDataInitializer());
            Console.WriteLine("=> ADO.NET Entity Framework 6 Code First (from Model)");
            using (var context = new AutoLotEntities())
                foreach (Inventory inventory in context.Inventory)
                    Console.WriteLine(inventory);
            Console.ReadLine();

            Console.WriteLine("=> Использование репозитория (Repository)");
            using (var inventoryRepo = new InventoryRepo())
                foreach (Inventory i in inventoryRepo.GetAll())
                    Console.WriteLine(i);
            Console.ReadLine();

            Console.WriteLine("=> Исключение параллельного обновления БД (DbUpdateConcurrencyException)");
            TestConcurrency();
            Console.ReadLine();
        }

        private static void AddInventory(Inventory inventory)
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (var inventoryRepo = new InventoryRepo())
                inventoryRepo.Add(inventory);
        }
        private static void UpdateInventory(int carId)
        {
            using (var inventoryRepo = new InventoryRepo())
            {
                // Извлечь запись об автомобиле, изменить ее и сохранить.
                var car = inventoryRepo.GetOne(carId);
                if (car == null)
                    return;
                car.Color = car.Color == "Blue" ? "Red" : "Blue";
                inventoryRepo.Save(car);
            }
        }
        private static void DeleteInventory(Inventory inventory)
        {
            using (var inventoryRepo = new InventoryRepo())
                inventoryRepo.Delete(inventory);
        }
        private static void DeleteInventoryById(int carId, byte[] timestamp)
        {
            using (var inventoryRepo = new InventoryRepo())
                inventoryRepo.Delete(carId, timestamp);
        }

        private static void TestConcurrency()
        {
            // Использовать второе хранилище, чтобы гарантировать
            // применение отличающегося контекста.
            var repo1 = new InventoryRepo();
            var repo2 = new InventoryRepo();
            Inventory car1 = repo1.GetOne(1);
            Inventory car2 = repo2.GetOne(1);
            car1.Name = "NewName";
            repo1.Save(car1);
            car2.Name = "OtherName";

            try
            {
                repo2.Save(car2);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                DbEntityEntry dbEntityEntry = ex.Entries.Single();
                DbPropertyValues originalValues = dbEntityEntry.OriginalValues;
                DbPropertyValues currentValues = dbEntityEntry.CurrentValues;
                DbPropertyValues databaseValues = dbEntityEntry.GetDatabaseValues();
                Console.WriteLine("|{0,65}| |{1,-49}|", "Этапы", "Значение свойства \"Name\" и \"Timestamp\"");
                Console.WriteLine("|{0,65}| |{1,-49}|", "", "отслеживаемой сущности");
                Console.WriteLine("|{0,65}| |{1,-23}; {2,-24}|", "Original (Исходный, При последнем обновлении контекста из БД)",
                    originalValues["Name"], ((byte[])originalValues["Timestamp"]).Last());
                Console.WriteLine("|{0,65}| |{1,-23}; {2,-24}|", "Current (Текущий, Исходное или измененное)",
                    currentValues["Name"], ((byte[])currentValues["Timestamp"]).Last());
                Console.WriteLine("|{0,65}| |{1,-23}; {2,-24}|", "Database (В БД, В БД в момент возникновения исключения) {0,57}",
                    databaseValues["Name"], ((byte[])databaseValues["Timestamp"]).Last());
            }
        }
    }
}
