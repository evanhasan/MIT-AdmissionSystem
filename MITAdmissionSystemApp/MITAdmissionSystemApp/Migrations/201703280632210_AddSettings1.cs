namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettings1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "ExamFee", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "ExamFee");
        }
    }
}
