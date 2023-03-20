namespace VET_CLINIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        AnimalTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Phone_number = c.Int(nullable: false),
                        Email_address = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalTypeID);
            
            CreateTable(
                "dbo.PetOwners",
                c => new
                    {
                        onwer_id = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                        Surname = c.String(),
                        Phone_number = c.Int(nullable: false),
                        Email_address = c.Int(nullable: false),
                        Postal_Address = c.String(),
                        ID_Number = c.Long(nullable: false),
                        AccountNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.onwer_id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        pet_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AnimalTypeID = c.Int(nullable: false),
                        Breed = c.String(),
                        onwer_id = c.Int(nullable: false),
                        Birthdate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.pet_id)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalTypeID, cascadeDelete: true)
                .ForeignKey("dbo.PetOwners", t => t.onwer_id, cascadeDelete: true)
                .Index(t => t.AnimalTypeID)
                .Index(t => t.onwer_id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vets",
                c => new
                    {
                        VetID = c.Int(nullable: false, identity: true),
                        VetName = c.String(),
                        VetSurName = c.String(),
                        ID_Number = c.Long(nullable: false),
                        MedicalLicenseNumber = c.String(),
                    })
                .PrimaryKey(t => t.VetID);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        pet_id = c.Int(nullable: false),
                        VetID = c.Int(nullable: false),
                        Email_address = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.Pets", t => t.pet_id, cascadeDelete: true)
                .ForeignKey("dbo.Vets", t => t.VetID, cascadeDelete: true)
                .Index(t => t.pet_id)
                .Index(t => t.VetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "VetID", "dbo.Vets");
            DropForeignKey("dbo.Visits", "pet_id", "dbo.Pets");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pets", "onwer_id", "dbo.PetOwners");
            DropForeignKey("dbo.Pets", "AnimalTypeID", "dbo.AnimalTypes");
            DropIndex("dbo.Visits", new[] { "VetID" });
            DropIndex("dbo.Visits", new[] { "pet_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pets", new[] { "onwer_id" });
            DropIndex("dbo.Pets", new[] { "AnimalTypeID" });
            DropTable("dbo.Visits");
            DropTable("dbo.Vets");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pets");
            DropTable("dbo.PetOwners");
            DropTable("dbo.AnimalTypes");
        }
    }
}
