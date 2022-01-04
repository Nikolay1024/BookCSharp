using AutoLotDataAccessLayer.EntityFramework;
using AutoLotDataAccessLayer.Models;
using AutoLotDataAccessLayer.Repos;
using System;

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

            Console.WriteLine("=> Использование репозитория");
            using (var inventoryRepo = new InventoryRepo())
                foreach (Inventory i in inventoryRepo.GetAll())
                    Console.WriteLine(i);
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
    }
}
