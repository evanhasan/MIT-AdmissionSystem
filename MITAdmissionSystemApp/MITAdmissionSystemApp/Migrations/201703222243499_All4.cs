namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "PhotoPath", c => c.String());
            AlterColumn("dbo.Registrations", "SignaturePath", c => c.String());
            AlterColumn("dbo.Registrations", "BachelorCertificatePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "BachelorCertificatePath", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "SignaturePath", c => c.String(nullable: false));
            AlterColumn("dbo.Registrations", "PhotoPath", c => c.String(nullable: false));
        }
    }
}
