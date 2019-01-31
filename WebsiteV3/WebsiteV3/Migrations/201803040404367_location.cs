namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "WhereToGet", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "WhereToGet");
        }
    }
}
