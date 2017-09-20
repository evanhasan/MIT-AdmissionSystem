namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "PhotoPath", c => c.String(nullable: false));
            AddColumn("dbo.Registrations", "SignaturePath", c => c.String(nullable: false));
            AddColumn("dbo.Registrations", "BachelorCertificatePath", c => c.String(nullable: false));
            DropColumn("dbo.Registrations", "Photo");
            DropColumn("dbo.Registrations", "Signature");
            DropColumn("dbo.Registrations", "BachelorCertificate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrations", "BachelorCertificate", c => c.String(nullable: false));
            AddColumn("dbo.Registrations", "Signature", c => c.String(nullable: false));
            AddColumn("dbo.Registrations", "Photo", c => c.String(nullable: false));
            DropColumn("dbo.Registrations", "BachelorCertificatePath");
            DropColumn("dbo.Registrations", "SignaturePath");
            DropColumn("dbo.Registrations", "PhotoPath");
        }
    }
}
