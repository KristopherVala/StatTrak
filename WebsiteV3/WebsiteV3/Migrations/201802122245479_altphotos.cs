namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altphotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "AltGameArt", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "AltGameArt");
        }
    }
}
