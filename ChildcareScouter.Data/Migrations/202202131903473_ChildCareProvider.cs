namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChildCareProcider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildCareProvider",
                c => new
                    {
                        Child_ChildID = c.Int(nullable: false),
                        CareProvider_CareProviderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Child_ChildID, t.CareProvider_CareProviderID })
                .ForeignKey("dbo.Child", t => t.Child_ChildID, cascadeDelete: false)
                .ForeignKey("dbo.CareProvider", t => t.CareProvider_CareProviderID, cascadeDelete: true)
                .Index(t => t.Child_ChildID)
                .Index(t => t.CareProvider_CareProviderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildCareProvider", "CareProvider_CareProviderID", "dbo.CareProvider");
            DropForeignKey("dbo.ChildCareProvider", "Child_ChildID", "dbo.Child");
            DropIndex("dbo.ChildCareProvider", new[] { "CareProvider_CareProviderID" });
            DropIndex("dbo.ChildCareProvider", new[] { "Child_ChildID" });
            DropTable("dbo.ChildCareProvider");
        }
    }
}
