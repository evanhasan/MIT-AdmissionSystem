namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "TrxId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "TrxId");
        }
    }
}
