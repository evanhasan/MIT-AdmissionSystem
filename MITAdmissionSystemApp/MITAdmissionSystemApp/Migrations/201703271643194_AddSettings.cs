namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamName = c.String(nullable: false),
                        ExamDescription = c.String(),
                        RegStartDate = c.DateTime(nullable: false),
                        RegEndDate = c.DateTime(nullable: false),
                        AdmitCardDate = c.DateTime(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                        Brochure = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
