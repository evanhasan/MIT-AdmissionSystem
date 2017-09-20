namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "RollNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "RollNumber");
        }
    }
}
