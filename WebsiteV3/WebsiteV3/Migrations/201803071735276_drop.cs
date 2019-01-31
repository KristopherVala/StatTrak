namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Password", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
