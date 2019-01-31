namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class screens : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Screenshots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Screenshot = c.String(),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Screenshots", "Game_Id", "dbo.Games");
            DropIndex("dbo.Screenshots", new[] { "Game_Id" });
            DropTable("dbo.Screenshots");
        }
    }
}
