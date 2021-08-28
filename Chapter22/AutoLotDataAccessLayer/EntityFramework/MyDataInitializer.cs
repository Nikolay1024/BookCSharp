using AutoLotDataAccessLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace AutoLotDataAccessLayer.EntityFramework
{
    public class MyDataInitializer : DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            var customers = new List<Customer>()
            {
                new Customer { FirstName = "Dave", LastName = "Brenner" },
                new Customer { FirstName = "Matt", LastName = "Walton" },
                new Customer { FirstName = "Steve", LastName = "Hagen" },
                new Customer { FirstName = "Pat", LastName = "Walton" },
                new Customer { FirstName = "Bad", LastName = "Customer" },
            };
            foreach (Customer customer in customers)
                context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, customer);

            var inventory = new List<Inventory>()
            {
                new Inventory("VW", "Black", "Zippy"),
                new Inventory("Ford", "Rust", "Rusty"),
                new Inventory("Saab", "Black", "Mel"),
                new Inventory("Yugo", "Yellow", "Clunker"),
                new Inventory("BMW", "Black", "Bimmer"),
                new Inventory("BMW", "Green", "Hank"),
                new Inventory("BMW", "Pink", "Pinky"),
                new Inventory("Pinto", "Black", "Pete"),
                new Inventory("Yugo", "Brown", "Brownie"),
            };
            inventory.ForEach(inv => context.Inventory.AddOrUpdate(i => new { i.Make, i.Color }, inv));
            
            var orders = new List<Order>()
            {
                new Order { Inventory = inventory[0], Customer = customers[0]},
                new Order { Inventory = inventory[1], Customer = customers[1]},
                new Order { Inventory = inventory[2], Customer = customers[2]},
                new Order { Inventory = inventory[3], Customer = customers[3]},
            };
            context.Orders.AddOrUpdate(o => new { o.CarId, o.CustomerId }, orders.ToArray());

            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
                new CreditRisk()
                {
                    CustomerId = customers[4].CustomerId,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
        }
    }
}
