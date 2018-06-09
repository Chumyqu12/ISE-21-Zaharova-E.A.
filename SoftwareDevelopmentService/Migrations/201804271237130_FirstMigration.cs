namespace SoftwareDevelopmentService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SoftwareId = c.Int(nullable: false),
                        DeveloperId = c.Int(),
                        Number = c.Int(nullable: false),
                        Summa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Condition = c.Int(nullable: false),
                        Creation = c.DateTime(nullable: false),
                        Implementation = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.DeveloperId)
                .ForeignKey("dbo.Softwares", t => t.SoftwareId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.SoftwareId)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SoftwareName = c.String(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SoftwareParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SoftwareId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Softwares", t => t.SoftwareId, cascadeDelete: true)
                .Index(t => t.SoftwareId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarehouseParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WarehouseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoftwareParts", "SoftwareId", "dbo.Softwares");
            DropForeignKey("dbo.WarehouseParts", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseParts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.SoftwareParts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.Offers", "SoftwareId", "dbo.Softwares");
            DropForeignKey("dbo.Offers", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.Offers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.WarehouseParts", new[] { "PartId" });
            DropIndex("dbo.WarehouseParts", new[] { "WarehouseId" });
            DropIndex("dbo.SoftwareParts", new[] { "PartId" });
            DropIndex("dbo.SoftwareParts", new[] { "SoftwareId" });
            DropIndex("dbo.Offers", new[] { "DeveloperId" });
            DropIndex("dbo.Offers", new[] { "SoftwareId" });
            DropIndex("dbo.Offers", new[] { "CustomerId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.WarehouseParts");
            DropTable("dbo.Parts");
            DropTable("dbo.SoftwareParts");
            DropTable("dbo.Softwares");
            DropTable("dbo.Developers");
            DropTable("dbo.Offers");
            DropTable("dbo.Customers");
        }
    }
}
