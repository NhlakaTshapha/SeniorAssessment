namespace VET_CLINIC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7th : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
