using AutoLotDataAccessLayer.Interception;
using AutoLotDataAccessLayer.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;

namespace AutoLotDataAccessLayer.EntityFramework
{
    public partial class AutoLotEntities : DbContext
    {
        static readonly DatabaseLogger DatabaseLogger = new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities() : base("name=AutoLotConnection")
        {
            // Добавление перехватчика IDbCommandInterceptor
            // DbInterception.Add(new ConsoleWriterInterceptor());

            // Добавление перехватчика DatabaseLogger
            DatabaseLogger.StartLogging();
            DbInterception.Add(DatabaseLogger);

            // Добавление перехватчика с помощью событий ObjectMaterialized и SavingChanges.
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.ObjectMaterialized += OnObjectMaterialized;
            objectContext.SavingChanges += OnSavingChanges;
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);
        }

        protected override void Dispose(bool disposing)
        {
            DbInterception.Remove(DatabaseLogger);
            DatabaseLogger.StopLogging();
            base.Dispose(disposing);
        }

        private void OnSavingChanges(object sender, EventArgs e)
        {
            if (sender is ObjectContext objectContext)
                foreach (ObjectStateEntry objectStateEntry in objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
                {
                    if (objectStateEntry.Entity is Inventory inventory)
                        if (inventory.Color == "Red")
                            objectStateEntry.RejectPropertyChanges("Color");
                }
        }
        private void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
        }
    }
}
