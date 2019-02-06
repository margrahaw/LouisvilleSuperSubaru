namespace LouisvilleSuperSubaru.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserRoleID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserRoleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRoleName");
            DropColumn("dbo.AspNetUsers", "UserRoleID");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
