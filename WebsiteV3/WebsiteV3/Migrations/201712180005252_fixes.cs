namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameDatas", "PlayerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameDatas", "PlayerName");
        }
    }
}
