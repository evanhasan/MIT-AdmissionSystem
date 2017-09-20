namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettings3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "AdmissionDateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Settings", "WrittenTest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "WrittenTest", c => c.DateTime(nullable: false));
            DropColumn("dbo.Settings", "AdmissionDateEnd");
        }
    }
}
