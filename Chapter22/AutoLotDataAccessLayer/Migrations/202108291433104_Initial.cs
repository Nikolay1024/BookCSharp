namespace AutoLotDataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditRisks",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(maxLength: 50),
                        last_name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(maxLength: 50),
                        last_name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        car_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.Customers", t => t.customer_id, cascadeDelete: true)
                .ForeignKey("dbo.Inventory", t => t.car_id)
                .Index(t => t.customer_id)
                .Index(t => t.car_id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        car_id = c.Int(nullable: false, identity: true),
                        make = c.String(maxLength: 50),
                        color = c.String(maxLength: 50),
                        name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.car_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "car_id", "dbo.Inventory");
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "car_id" });
            DropIndex("dbo.Orders", new[] { "customer_id" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditRisks");
        }
    }
}
