namespace Optiek_Declercq.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptiekDeclercqDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        PostCode = c.String(),
                        StreetWithNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyVatNumber = c.String(),
                        CompanyProFormaBilling = c.Boolean(nullable: false),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmailAdress = c.String(),
                        PhoneNumber = c.String(),
                        AddressID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .ForeignKey("dbo.Company", t => t.CompanyID)
                .Index(t => t.AddressID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InvoiceRule",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmailAdress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceRule", "InvoiceId", "dbo.Invoice");
            DropForeignKey("dbo.Customer", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.Customer", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Company", "AddressID", "dbo.Address");
            DropIndex("dbo.InvoiceRule", new[] { "InvoiceId" });
            DropIndex("dbo.Customer", new[] { "CompanyID" });
            DropIndex("dbo.Customer", new[] { "AddressID" });
            DropIndex("dbo.Company", new[] { "AddressID" });
            DropTable("dbo.Invoice");
            DropTable("dbo.InvoiceRule");
            DropTable("dbo.ErrorLog");
            DropTable("dbo.Customer");
            DropTable("dbo.Company");
            DropTable("dbo.Address");
        }
    }
}
