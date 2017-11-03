namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LayersAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        LayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LayerId)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_LayerName")
                .Index(t => t.ManufacturerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Layers", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Layers", new[] { "ManufacturerId" });
            DropIndex("dbo.Layers", "IX_LayerName");
            DropTable("dbo.Layers");
        }
    }
}
