namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortListAdmit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "ShortList", c => c.Int(nullable: false));
            AddColumn("dbo.Registrations", "Admit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "Admit");
            DropColumn("dbo.Registrations", "ShortList");
        }
    }
}
