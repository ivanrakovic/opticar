namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryTimes",
                c => new
                    {
                        DeliveryTimeId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DeliveryTimeId)
                .Index(t => t.Description, unique: true, name: "IX_DeliveryTimeDesc");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DeliveryTimes", "IX_DeliveryTimeDesc");
            DropTable("dbo.DeliveryTimes");
        }
    }
}
