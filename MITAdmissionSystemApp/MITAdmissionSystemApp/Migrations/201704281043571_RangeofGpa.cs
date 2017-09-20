namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RangeofGpa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "SSCPoint", c => c.Double(nullable: false));
            AlterColumn("dbo.Registrations", "HSCPoint", c => c.Double(nullable: false));
            AlterColumn("dbo.Registrations", "BachelorGrade", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "BachelorGrade", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "HSCPoint", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Registrations", "SSCPoint", c => c.String(nullable: false));
        }
    }
}
