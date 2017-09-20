namespace MITAdmissionSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class All : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Designation = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Bachelors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Digree = c.String(),
                        Decription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameofApplicant = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ParmanentAddress = c.String(nullable: false),
                        Nationality = c.String(nullable: false),
                        MobileNo = c.String(nullable: false),
                        DateofBirth = c.DateTime(nullable: false),
                        SSCSchool = c.String(nullable: false),
                        SSCYear = c.String(nullable: false, maxLength: 5),
                        SSCGroup = c.String(nullable: false),
                        SSCPoint = c.String(nullable: false),
                        HSCCollege = c.String(nullable: false),
                        HSCYear = c.String(nullable: false, maxLength: 5),
                        HSCGroup = c.String(nullable: false),
                        HSCPoint = c.String(nullable: false),
                        BachelorId = c.String(nullable: false),
                        BachelorUniversity = c.String(nullable: false),
                        BachelorYear = c.String(nullable: false),
                        BachelorGrade = c.String(nullable: false),
                        MasterUniversity = c.String(nullable: false),
                        MasterYear = c.String(nullable: false),
                        MasterGrade = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        Signature = c.String(nullable: false),
                        BachelorCertificate = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
            DropTable("dbo.Bachelors");
            DropTable("dbo.Admins");
        }
    }
}
