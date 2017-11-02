namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiameterValueUniqueIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Diameters", "Value", unique: true, name: "IX_DiameterValue");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Diameters", "IX_DiameterValue");
        }
    }
}
