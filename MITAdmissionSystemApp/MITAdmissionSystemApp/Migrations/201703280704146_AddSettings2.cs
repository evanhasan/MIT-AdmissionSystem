namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettings2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "ExamTime", c => c.String());
            AddColumn("dbo.Settings", "Venue", c => c.String());
            AddColumn("dbo.Settings", "WrittenTest", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "WrittenTestResult", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "VivaDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "FinalResult", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "AdmissionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "AdmissionDateWaitingList", c => c.DateTime(nullable: false));
            AddColumn("dbo.Settings", "ClassStart", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "ClassStart");
            DropColumn("dbo.Settings", "AdmissionDateWaitingList");
            DropColumn("dbo.Settings", "AdmissionDate");
            DropColumn("dbo.Settings", "FinalResult");
            DropColumn("dbo.Settings", "VivaDate");
            DropColumn("dbo.Settings", "WrittenTestResult");
            DropColumn("dbo.Settings", "WrittenTest");
            DropColumn("dbo.Settings", "Venue");
            DropColumn("dbo.Settings", "ExamTime");
        }
    }
}
