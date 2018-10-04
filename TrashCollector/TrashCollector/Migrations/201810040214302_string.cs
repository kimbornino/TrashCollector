namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickupStartDate", c => c.String());
            AlterColumn("dbo.Customers", "PickupEndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PickupEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickupStartDate", c => c.DateTime(nullable: false));
        }
    }
}
