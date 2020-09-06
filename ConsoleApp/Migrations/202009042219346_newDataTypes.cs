namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDataTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Currencies", "Quantity", c => c.String());
            AlterColumn("dbo.Rates", "Date", c => c.String());
            AlterColumn("dbo.Rates", "Value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rates", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rates", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Currencies", "Quantity", c => c.Int(nullable: false));
        }
    }
}
