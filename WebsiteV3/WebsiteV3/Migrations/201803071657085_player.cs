namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class player : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Player_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Player_Id");
            AddForeignKey("dbo.AspNetUsers", "Player_Id", "dbo.Players", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Player_Id", "dbo.Players");
            DropIndex("dbo.AspNetUsers", new[] { "Player_Id" });
            DropColumn("dbo.AspNetUsers", "Player_Id");
        }
    }
}
