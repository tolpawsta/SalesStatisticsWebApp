namespace SalesStatistics.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Managers", "ReportId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Managers", "ReportId", c => c.Int(nullable: false));
        }
    }
}
