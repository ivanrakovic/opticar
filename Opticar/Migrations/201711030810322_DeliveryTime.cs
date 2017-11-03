namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliveryTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MaterialTypes", "Description", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.MaterialTypes", "Description", unique: true, name: "IX_MaterialTypeDesc");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MaterialTypes", "IX_MaterialTypeDesc");
            AlterColumn("dbo.MaterialTypes", "Description", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
