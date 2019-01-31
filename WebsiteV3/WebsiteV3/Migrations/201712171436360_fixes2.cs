namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "GameData_Id", "dbo.GameDatas");
            DropIndex("dbo.Players", new[] { "GameData_Id" });
            AddColumn("dbo.GameDatas", "Player_Id", c => c.Int());
            CreateIndex("dbo.GameDatas", "Player_Id");
            AddForeignKey("dbo.GameDatas", "Player_Id", "dbo.Players", "Id");
            DropColumn("dbo.Players", "GameData_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "GameData_Id", c => c.Int());
            DropForeignKey("dbo.GameDatas", "Player_Id", "dbo.Players");
            DropIndex("dbo.GameDatas", new[] { "Player_Id" });
            DropColumn("dbo.GameDatas", "Player_Id");
            CreateIndex("dbo.Players", "GameData_Id");
            AddForeignKey("dbo.Players", "GameData_Id", "dbo.GameDatas", "Id");
        }
    }
}
