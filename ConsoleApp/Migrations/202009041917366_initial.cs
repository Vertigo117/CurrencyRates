namespace ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .Index(t => t.Currency_Id);
            
            DropTable("dbo.CurrencyRates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CurrencyRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        _1AUD = c.Decimal(name: "1 AUD", nullable: false, precision: 18, scale: 2),
                        _1BGN = c.Decimal(name: "1 BGN", nullable: false, precision: 18, scale: 2),
                        _1BRL = c.Decimal(name: "1 BRL", nullable: false, precision: 18, scale: 2),
                        _1CAD = c.Decimal(name: "1 CAD", nullable: false, precision: 18, scale: 2),
                        _1CHF = c.Decimal(name: "1 CHF", nullable: false, precision: 18, scale: 2),
                        _1CNY = c.Decimal(name: "1 CNY", nullable: false, precision: 18, scale: 2),
                        _1DKK = c.Decimal(name: "1 DKK", nullable: false, precision: 18, scale: 2),
                        _1EUR = c.Decimal(name: "1 EUR", nullable: false, precision: 18, scale: 2),
                        _1GBP = c.Decimal(name: "1 GBP", nullable: false, precision: 18, scale: 2),
                        _1HKD = c.Decimal(name: "1 HKD", nullable: false, precision: 18, scale: 2),
                        _1HRK = c.Decimal(name: "1 HRK", nullable: false, precision: 18, scale: 2),
                        _100HUF = c.Decimal(name: "100 HUF", nullable: false, precision: 18, scale: 2),
                        _1000IDR = c.Decimal(name: "1000 IDR", nullable: false, precision: 18, scale: 2),
                        _1ILS = c.Decimal(name: "1 ILS", nullable: false, precision: 18, scale: 2),
                        _100INR = c.Decimal(name: "100 INR", nullable: false, precision: 18, scale: 2),
                        _100JPY = c.Decimal(name: "100 JPY", nullable: false, precision: 18, scale: 2),
                        _100KRW = c.Decimal(name: "100 KRW", nullable: false, precision: 18, scale: 2),
                        _1MXN = c.Decimal(name: "1 MXN", nullable: false, precision: 18, scale: 2),
                        _1MYR = c.Decimal(name: "1 MYR", nullable: false, precision: 18, scale: 2),
                        _1NOK = c.Decimal(name: "1 NOK", nullable: false, precision: 18, scale: 2),
                        _1NZD = c.Decimal(name: "1 NZD", nullable: false, precision: 18, scale: 2),
                        _100PHP = c.Decimal(name: "100 PHP", nullable: false, precision: 18, scale: 2),
                        _1PLN = c.Decimal(name: "1 PLN", nullable: false, precision: 18, scale: 2),
                        _1RON = c.Decimal(name: "1 RON", nullable: false, precision: 18, scale: 2),
                        _100RUB = c.Decimal(name: "100 RUB", nullable: false, precision: 18, scale: 2),
                        _1SEK = c.Decimal(name: "1 SEK", nullable: false, precision: 18, scale: 2),
                        _1SGD = c.Decimal(name: "1 SGD", nullable: false, precision: 18, scale: 2),
                        _100THB = c.Decimal(name: "100 THB", nullable: false, precision: 18, scale: 2),
                        _1TRY = c.Decimal(name: "1 TRY", nullable: false, precision: 18, scale: 2),
                        _1USD = c.Decimal(name: "1 USD", nullable: false, precision: 18, scale: 2),
                        _1XDR = c.Decimal(name: "1 XDR", nullable: false, precision: 18, scale: 2),
                        _1ZAR = c.Decimal(name: "1 ZAR", nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Rates", "Currency_Id", "dbo.Currencies");
            DropIndex("dbo.Rates", new[] { "Currency_Id" });
            DropTable("dbo.Rates");
            DropTable("dbo.Currencies");
        }
    }
}
