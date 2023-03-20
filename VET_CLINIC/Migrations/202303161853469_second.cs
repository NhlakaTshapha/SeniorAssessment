namespace VET_CLINIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "VisitDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Visits", "Email_address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Visits", "Email_address", c => c.Int(nullable: false));
            DropColumn("dbo.Visits", "VisitDate");
        }
    }
}
