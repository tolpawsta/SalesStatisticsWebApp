namespace SalesStatistics.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Login");
            DropColumn("dbo.AspNetUsers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Login", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
