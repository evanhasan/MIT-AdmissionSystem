using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MITAdmissionSystemApp.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name="Name")]
        public string NameofApplicant { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Permanent Address")]
        public string ParmanentAddress { get; set; }
        [Required]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
        [Required]
        [Display(Name = "Contact No")]
        public string MobileNo { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { get; set; }
        [Required]
        [Display(Name = "School")]
        public string SSCSchool { get; set; }
        [Required, MaxLength(4, ErrorMessage = "Year have to be within 4 letter")]
        [Display(Name = "Passing Year")]
        public string SSCYear { get; set; }
        [Required]
        [Display(Name = "Group")]
        public string SSCGroup { get; set; }
        [Required]
        [Display(Name = "GPA"),Range(2,5)]
        public double SSCPoint { get; set; }

        [Required]
        [Display(Name = "College")]
        public string HSCCollege { get; set; }
        [Required, MaxLength(4, ErrorMessage = "Year have to be within 4 letter")]
        [Display(Name = "Passing Year")]
        public string HSCYear { get; set; }
        [Required]
        [Display(Name = "Group")]
        public string HSCGroup { get; set; }
        [Required]
        [Display(Name = "GPA"),Range(2,5)]
        public double HSCPoint { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string BachelorId { get; set; }
        [Required]
        [Display(Name = "University")]
        public string BachelorUniversity { get; set; }
        [Required]
        [Display(Name = "Passing Year")]
        public string BachelorYear { get; set; }
        [Required]
        [Display(Name = "GPA"),Range(2,5)]
        public double BachelorGrade { get; set; }

         [Display(Name = "University")]
        public string MasterUniversity { get; set; }
         [Display(Name = "Year")]
        public string MasterYear { get; set; }
         [Display(Name = "GPA")]
        public string MasterGrade { get; set; }

     
        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }
       
        [Display(Name = "Signature")]
        public string SignaturePath { get; set; }
       
        [Display(Name = "Certificate")]
        public string BachelorCertificatePath { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

         [Display(Name = "Payment Status")]
        public int PayStatus { get; set; }

         [Display(Name = "Transaction ID")]
        public int TrxId { get; set; }

         [Display(Name = "Short List")]
        public int ShortList { get; set; }

         [Display(Name = "Admit Card")]
        public int Admit { get; set; }

         [Display(Name = "Roll Number")]
         public int RollNumber { get; set; }
    }
}