namespace WebsiteV3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Role");
        }
    }
}
