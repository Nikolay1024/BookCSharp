namespace AutoLotDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "car_id", "dbo.Inventory");
            DropPrimaryKey("dbo.CreditRisks");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Inventory");
            DropColumn("dbo.CreditRisks", "customer_id");
            DropColumn("dbo.Customers", "customer_id");
            DropColumn("dbo.Orders", "order_id");
            DropColumn("dbo.Inventory", "car_id");
            AddColumn("dbo.CreditRisks", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddPrimaryKey("dbo.CreditRisks", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            AddPrimaryKey("dbo.Inventory", "Id");
            CreateIndex("dbo.CreditRisks", new[] { "last_name", "first_name" }, unique: true, name: "IDX_CreditRisk_Name");
            AddForeignKey("dbo.Orders", "customer_id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "car_id", "dbo.Inventory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "car_id", "dbo.Inventory");
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
            DropPrimaryKey("dbo.Inventory");
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.CreditRisks");
            DropColumn("dbo.Inventory", "Timestamp");
            DropColumn("dbo.Inventory", "Id");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.CreditRisks", "Timestamp");
            DropColumn("dbo.CreditRisks", "Id");
            AddColumn("dbo.Inventory", "car_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "order_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "customer_id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisks", "customer_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Inventory", "car_id");
            AddPrimaryKey("dbo.Orders", "order_id");
            AddPrimaryKey("dbo.Customers", "customer_id");
            AddPrimaryKey("dbo.CreditRisks", "customer_id");
            AddForeignKey("dbo.Orders", "car_id", "dbo.Inventory", "car_id");
            AddForeignKey("dbo.Orders", "customer_id", "dbo.Customers", "customer_id", cascadeDelete: true);
        }
    }
}
