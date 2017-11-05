namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLenseType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LenseTypes",
                c => new
                    {
                        LenseTypeId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LenseTypeId)
                .Index(t => t.DisplayName, unique: true, name: "IX_LenseTypeDesc");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LenseTypes", "IX_LenseTypeDesc");
            DropTable("dbo.LenseTypes");
        }
    }
}
