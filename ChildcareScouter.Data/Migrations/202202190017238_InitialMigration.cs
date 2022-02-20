namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Licensed", "Careprovider_CareproviderID", "dbo.Careprovider");
            DropIndex("dbo.Licensed", new[] { "Careprovider_CareproviderID" });
            DropTable("dbo.Licensed");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Licensed",
                c => new
                    {
                        LicensedID = c.Int(nullable: false, identity: true),
                        CertificateName = c.String(nullable: false),
                        Certified = c.Boolean(nullable: false),
                        CPRTraining = c.Boolean(nullable: false),
                        CriminalBackground = c.Boolean(nullable: false),
                        Inspection = c.Boolean(nullable: false),
                        DateRequired = c.DateTime(nullable: false),
                        ChildNumber = c.Int(nullable: false),
                        StateRegistered = c.Boolean(nullable: false),
                        Careprovider_CareproviderID = c.Int(),
                    })
                .PrimaryKey(t => t.LicensedID);
            
            CreateIndex("dbo.Licensed", "Careprovider_CareproviderID");
            AddForeignKey("dbo.Licensed", "Careprovider_CareproviderID", "dbo.Careprovider", "CareproviderID");
        }
    }
}
