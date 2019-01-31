namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wahoo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Player_Id", "dbo.Players");
            DropIndex("dbo.AspNetUsers", new[] { "Player_Id" });
            AddColumn("dbo.Players", "Password", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.AspNetUsers", "ProfilePhoto");
            DropColumn("dbo.AspNetUsers", "Player_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Player_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ProfilePhoto", c => c.String());
            DropColumn("dbo.Players", "Password");
            CreateIndex("dbo.AspNetUsers", "Player_Id");
            AddForeignKey("dbo.AspNetUsers", "Player_Id", "dbo.Players", "Id");
        }
    }
}
