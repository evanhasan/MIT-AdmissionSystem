namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegPoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "SSCYear", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Registrations", "HSCYear", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Registrations", "HSCPoint", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "HSCPoint", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "HSCYear", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Registrations", "SSCYear", c => c.String(nullable: false, maxLength: 5));
        }
    }
}
