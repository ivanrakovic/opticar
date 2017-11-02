namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diameters",
                c => new
                    {
                        DiameterId = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DiameterId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ManufacturerId)
                .Index(t => t.Name, unique: true, name: "IX_ManufacturerName");
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaterialTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.MaterialTypes", t => t.MaterialTypeId, cascadeDelete: true)
                .Index(t => t.MaterialTypeId);
            
            CreateTable(
                "dbo.MaterialTypes",
                c => new
                    {
                        MaterialTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MaterialTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "MaterialTypeId", "dbo.MaterialTypes");
            DropIndex("dbo.Materials", new[] { "MaterialTypeId" });
            DropIndex("dbo.Manufacturers", "IX_ManufacturerName");
            DropTable("dbo.MaterialTypes");
            DropTable("dbo.Materials");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Diameters");
        }
    }
}
