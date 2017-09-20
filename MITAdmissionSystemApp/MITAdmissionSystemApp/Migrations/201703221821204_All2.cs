namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "MasterUniversity", c => c.String());
            AlterColumn("dbo.Registrations", "MasterYear", c => c.String());
            AlterColumn("dbo.Registrations", "MasterGrade", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "MasterGrade", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "MasterYear", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "MasterUniversity", c => c.String(nullable: false));
        }
    }
}
