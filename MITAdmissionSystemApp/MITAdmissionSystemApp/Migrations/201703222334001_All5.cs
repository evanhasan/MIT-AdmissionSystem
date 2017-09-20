namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "PayStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "PayStatus");
        }
    }
}
