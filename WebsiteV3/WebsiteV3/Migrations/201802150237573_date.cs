namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "LastLoginDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "LastLoginDate");
        }
    }
}
