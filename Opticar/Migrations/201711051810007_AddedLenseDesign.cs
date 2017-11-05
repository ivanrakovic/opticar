namespace Opticar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLenseDesign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LenseDesigns",
                c => new
                    {
                        LenseDesignId = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LenseDesignId)
                .Index(t => t.DisplayName, unique: true, name: "IX_LenseDesignDesc");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LenseDesigns", "IX_LenseDesignDesc");
            DropTable("dbo.LenseDesigns");
        }
    }
}
