namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Art", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Games", "GameArt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "GameArt", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Games", "Art");
        }
    }
}
