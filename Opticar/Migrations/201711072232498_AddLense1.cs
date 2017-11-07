namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLense1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes");
            DropForeignKey("dbo.Lenses", "LayerId", "dbo.Layers");
            DropForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns");
            DropForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes");
            DropForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            AddForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes", "DeliveryTimeId");
            AddForeignKey("dbo.Lenses", "LayerId", "dbo.Layers", "LayerId");
            AddForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns", "LenseDesignId");
            AddForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes", "LenseTypeId");
            AddForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId");
            AddForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes", "MaterialTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes");
            DropForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns");
            DropForeignKey("dbo.Lenses", "LayerId", "dbo.Layers");
            DropForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes");
            AddForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes", "MaterialTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId", cascadeDelete: true);
            AddForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes", "LenseTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns", "LenseDesignId", cascadeDelete: true);
            AddForeignKey("dbo.Lenses", "LayerId", "dbo.Layers", "LayerId", cascadeDelete: true);
            AddForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes", "DeliveryTimeId", cascadeDelete: true);
        }
    }
}
