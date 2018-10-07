namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerZip", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeZip", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeZip", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "CustomerZip", c => c.Double(nullable: false));
        }
    }
}
