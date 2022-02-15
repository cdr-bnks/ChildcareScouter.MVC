namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Parent", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employee", "UserID");
            CreateIndex("dbo.Parent", "UserID");
            AddForeignKey("dbo.Employee", "UserID", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Parent", "UserID", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parent", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Employee", "UserID", "dbo.ApplicationUser");
            DropIndex("dbo.Parent", new[] { "UserID" });
            DropIndex("dbo.Employee", new[] { "UserID" });
            DropColumn("dbo.Parent", "UserID");
            DropColumn("dbo.Employee", "UserID");
        }
    }
}
