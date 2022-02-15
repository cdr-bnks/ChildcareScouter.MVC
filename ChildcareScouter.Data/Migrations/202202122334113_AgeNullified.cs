namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeNullified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Age", c => c.Int());
            AlterColumn("dbo.Child", "Age", c => c.Int());
            AlterColumn("dbo.Parent", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parent", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Child", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "Age", c => c.Int(nullable: false));
        }
    }
}
