namespace ChildcareScouter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CareProvider",
                c => new
                    {
                        CareProviderID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        ProviderName = c.String(nullable: false),
                        ProviderTitle = c.String(nullable: false),
                        ContactInfo = c.String(nullable: false),
                        FullTime = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CareProviderID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Policy = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Licensed",
                c => new
                    {
                        LicensedID = c.Int(nullable: false),
                        CertificateName = c.String(),
                        Certified = c.Boolean(nullable: false),
                        CPRTraining = c.Boolean(nullable: false),
                        CriminalBackground = c.Boolean(nullable: false),
                        ChildNumber = c.Int(nullable: false),
                        Inspection = c.Boolean(nullable: false),
                        StateRegistered = c.Boolean(nullable: false),
                        DateRequired = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LicensedID)
                .ForeignKey("dbo.CareProvider", t => t.LicensedID)
                .Index(t => t.LicensedID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        MaritalStatus = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        IdentifyAs = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Race = c.String(nullable: false),
                        Religion = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Child",
                c => new
                    {
                        ChildID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        ChildNeeds = c.String(nullable: false),
                        FoodAllergens = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        IdentifyAs = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Race = c.String(nullable: false),
                        Religion = c.String(),
                    })
                .PrimaryKey(t => t.ChildID)
                .ForeignKey("dbo.Parent", t => t.ParentID, cascadeDelete: true)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        IdentifyAs = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Race = c.String(nullable: false),
                        Religion = c.String(),
                    })
                .PrimaryKey(t => t.ParentID)
                .ForeignKey("dbo.Company", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.EmployeeCareProvider",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        CareProvider_CareProviderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.CareProvider_CareProviderID })
                .ForeignKey("dbo.Employee", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.CareProvider", t => t.CareProvider_CareProviderID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.CareProvider_CareProviderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Child", "ParentID", "dbo.Parent");
            DropForeignKey("dbo.Parent", "CompanyID", "dbo.Company");
            DropForeignKey("dbo.EmployeeCareProvider", "CareProvider_CareProviderID", "dbo.CareProvider");
            DropForeignKey("dbo.EmployeeCareProvider", "Employee_EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.Licensed", "LicensedID", "dbo.CareProvider");
            DropForeignKey("dbo.CareProvider", "CompanyID", "dbo.Company");
            DropIndex("dbo.EmployeeCareProvider", new[] { "CareProvider_CareProviderID" });
            DropIndex("dbo.EmployeeCareProvider", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Parent", new[] { "CompanyID" });
            DropIndex("dbo.Child", new[] { "ParentID" });
            DropIndex("dbo.Licensed", new[] { "LicensedID" });
            DropIndex("dbo.CareProvider", new[] { "CompanyID" });
            DropTable("dbo.EmployeeCareProvider");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Parent");
            DropTable("dbo.Child");
            DropTable("dbo.Employee");
            DropTable("dbo.Licensed");
            DropTable("dbo.Company");
            DropTable("dbo.CareProvider");
        }
    }
}
