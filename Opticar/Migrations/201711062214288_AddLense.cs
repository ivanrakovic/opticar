namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLense : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.LenseId)
                .ForeignKey("dbo.DeliveryTimes", t => t.DeliveryTimeId, cascadeDelete: true)
                .ForeignKey("dbo.Layers", t => t.LayerId, cascadeDelete: true)
                .ForeignKey("dbo.LenseDesigns", t => t.LenseDesignId, cascadeDelete: true)
                .ForeignKey("dbo.LenseTypes", t => t.LenseTypeId, cascadeDelete: true)
                .Index(t => t.ManufacturerLenseId, unique: true)
                .Index(t => t.InternalLenseId, unique: true)
                .Index(t => t.FullName, unique: true, name: "IX_LenseFullName")
                .Index(t => t.LayerId)
                .Index(t => t.LenseTypeId)
                .Index(t => t.DeliveryTimeId)
                .Index(t => t.LenseDesignId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lenses", "LenseTypeId", "dbo.LenseTypes");
            DropForeignKey("dbo.Lenses", "LenseDesignId", "dbo.LenseDesigns");
            DropForeignKey("dbo.Lenses", "LayerId", "dbo.Layers");
            DropForeignKey("dbo.Lenses", "DeliveryTimeId", "dbo.DeliveryTimes");
            DropIndex("dbo.Lenses", new[] { "LenseDesignId" });
            DropIndex("dbo.Lenses", new[] { "DeliveryTimeId" });
            DropIndex("dbo.Lenses", new[] { "LenseTypeId" });
            DropIndex("dbo.Lenses", new[] { "LayerId" });
            DropIndex("dbo.Lenses", "IX_LenseFullName");
            DropIndex("dbo.Lenses", new[] { "InternalLenseId" });
            DropIndex("dbo.Lenses", new[] { "ManufacturerLenseId" });
            DropTable("dbo.Lenses");
        }
    }
}
