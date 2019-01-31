namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Players", "Game_Id1", "dbo.Games");
            DropIndex("dbo.Games", new[] { "Player_Id" });
            DropIndex("dbo.Players", new[] { "Game_Id1" });
            AddColumn("dbo.Players", "GameData_Id", c => c.Int());
            CreateIndex("dbo.Players", "GameData_Id");
            AddForeignKey("dbo.Players", "GameData_Id", "dbo.GameDatas", "Id");
            DropColumn("dbo.Games", "Player_Id");
            DropColumn("dbo.Players", "Game_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Game_Id1", c => c.Int());
            AddColumn("dbo.Games", "Player_Id", c => c.Int());
            DropForeignKey("dbo.Players", "GameData_Id", "dbo.GameDatas");
            DropIndex("dbo.Players", new[] { "GameData_Id" });
            DropColumn("dbo.Players", "GameData_Id");
            CreateIndex("dbo.Players", "Game_Id1");
            CreateIndex("dbo.Games", "Player_Id");
            AddForeignKey("dbo.Players", "Game_Id1", "dbo.Games", "Id");
            AddForeignKey("dbo.Games", "Player_Id", "dbo.Players", "Id");
        }
    }
}
