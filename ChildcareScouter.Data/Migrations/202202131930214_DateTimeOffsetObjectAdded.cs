namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeOffsetObjectAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CareProvider", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.CareProvider", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Child", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Child", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Parent", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Parent", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Company", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Company", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employee", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Employee", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Modified");
            DropColumn("dbo.Employee", "CreatedUtc");
            DropColumn("dbo.Company", "Modified");
            DropColumn("dbo.Company", "CreatedUtc");
            DropColumn("dbo.Parent", "Modified");
            DropColumn("dbo.Parent", "CreatedUtc");
            DropColumn("dbo.Child", "Modified");
            DropColumn("dbo.Child", "CreatedUtc");
            DropColumn("dbo.CareProvider", "Modified");
            DropColumn("dbo.CareProvider", "CreatedUtc");
        }
    }
}
