using AutoLotDataAccessLayer.EntityFramework;
using AutoLotDataAccessLayer.Models;
using System;
using System.Data.Entity;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MyDataInitializer());
            Console.WriteLine("=> ADO.NET Entity Framework 6 Code First (from Model)");
            using (AutoLotEntities context = new AutoLotEntities())
                foreach (Inventory inventory in context.Inventory)
                    Console.WriteLine(inventory);
            Console.ReadLine();
        }
    }
}
