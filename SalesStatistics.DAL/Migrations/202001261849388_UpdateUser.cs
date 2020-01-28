namespace SalesStatistics.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            AddColumn("dbo.AspNetUserRoles", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "UserRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUserRoles", "User_Id");
            AddForeignKey("dbo.AspNetUserRoles", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUserRoles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "User_Id" });
            AlterColumn("dbo.AspNetUsers", "UserRoleId", c => c.Int());
            DropColumn("dbo.AspNetUserRoles", "User_Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
