namespace SalesStatistics.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitUserPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Login", c => c.String());
            DropColumn("dbo.AspNetUsers", "Password");
        }
    }
}
