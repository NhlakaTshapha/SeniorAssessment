namespace VET_CLINIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PetOwners", "Email_address", c => c.String());
            DropColumn("dbo.AnimalTypes", "Surname");
            DropColumn("dbo.AnimalTypes", "Phone_number");
            DropColumn("dbo.AnimalTypes", "Email_address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnimalTypes", "Email_address", c => c.Int(nullable: false));
            AddColumn("dbo.AnimalTypes", "Phone_number", c => c.Int(nullable: false));
            AddColumn("dbo.AnimalTypes", "Surname", c => c.String());
            AlterColumn("dbo.PetOwners", "Email_address", c => c.Int(nullable: false));
        }
    }
}
