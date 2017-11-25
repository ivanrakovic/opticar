namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes");
            DropForeignKey("dbo.Lenses", "LayerId", "dbo.Layers");
            DropForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns");
            DropForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes");
            DropForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropIndex("dbo.Lenses", new[] { "ManufacturerLenseId" });
            DropIndex("dbo.Lenses", new[] { "InternalLenseId" });
            DropIndex("dbo.Lenses", "IX_LenseFullName");
            DropIndex("dbo.Lenses", new[] { "LayerId" });
            DropIndex("dbo.Lenses", new[] { "LenseTypeId" });
            DropIndex("dbo.Lenses", new[] { "DeliveryTimeId" });
            DropIndex("dbo.Lenses", new[] { "LenseDesignId" });
            AddForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId", cascadeDelete: true);
            AddForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes", "MaterialTypeId", cascadeDelete: true);
            DropTable("dbo.Lenses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lenses",
                c => new
                    {
                        LenseId = c.Int(nullable: false, identity: true),
                        ManufacturerLenseId = c.String(nullable: false, maxLength: 20),
                        InternalLenseId = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Lager = c.Boolean(nullable: false),
                        LocalLager = c.Boolean(nullable: false),
                        Special = c.Boolean(nullable: false),
                        Transition = c.Boolean(nullable: false),
                        Sunglass = c.Boolean(nullable: false),
                        Polarisation = c.Boolean(nullable: false),
                        BrandId = c.Int(nullable: false),
                        LayerId = c.Int(nullable: false),
                        LenseTypeId = c.Int(nullable: false),
                        DeliveryTimeId = c.Int(nullable: false),
                        LenseDesignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LenseId);
            
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers");
            CreateIndex("dbo.Lenses", "LenseDesignId");
            CreateIndex("dbo.Lenses", "DeliveryTimeId");
            CreateIndex("dbo.Lenses", "LenseTypeId");
            CreateIndex("dbo.Lenses", "LayerId");
            CreateIndex("dbo.Lenses", "FullName", unique: true, name: "IX_LenseFullName");
            CreateIndex("dbo.Lenses", "InternalLenseId", unique: true);
            CreateIndex("dbo.Lenses", "ManufacturerLenseId", unique: true);
            AddForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes", "MaterialTypeId");
            AddForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId");
            AddForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes", "LenseTypeId");
            AddForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns", "LenseDesignId");
            AddForeignKey("dbo.Lenses", "LayerId", "dbo.Layers", "LayerId");
            AddForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes", "DeliveryTimeId");
        }
    }
}
