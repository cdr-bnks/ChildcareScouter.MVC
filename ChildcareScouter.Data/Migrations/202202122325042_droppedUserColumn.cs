namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droppedUserColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Parent", "UserID", "dbo.ApplicationUser");
            DropIndex("dbo.Employee", new[] { "UserID" });
            DropIndex("dbo.Parent", new[] { "UserID" });
            DropColumn("dbo.Employee", "UserID");
            DropColumn("dbo.Parent", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parent", "UserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Employee", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Parent", "UserID");
            CreateIndex("dbo.Employee", "UserID");
            AddForeignKey("dbo.Parent", "UserID", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Employee", "UserID", "dbo.ApplicationUser", "Id");
        }
    }
}
