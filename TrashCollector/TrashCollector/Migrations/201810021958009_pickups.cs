namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pickups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pickups",
                c => new
                    {
                        PickupID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        ConfirmPickup = c.Boolean(nullable: false),
                        PickupDay = c.String(),
                        CustomPickup = c.String(),
                    })
                .PrimaryKey(t => t.PickupID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pickups", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Pickups", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Pickups", new[] { "EmployeeID" });
            DropIndex("dbo.Pickups", new[] { "CustomerID" });
            DropTable("dbo.Pickups");
        }
    }
}
