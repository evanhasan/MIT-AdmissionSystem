namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class flotetoDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "SSCPoint", c => c.Double(nullable: false));
            AlterColumn("dbo.Registrations", "HSCPoint", c => c.Double(nullable: false));
            AlterColumn("dbo.Registrations", "BachelorGrade", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "BachelorGrade", c => c.Single(nullable: false));
            AlterColumn("dbo.Registrations", "HSCPoint", c => c.Single(nullable: false));
            AlterColumn("dbo.Registrations", "SSCPoint", c => c.Single(nullable: false));
        }
    }
}
