using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MITAdmissionSystemApp.Models
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExamName { get; set; }
        public string ExamDescription { get; set; }
        [Required]
        public DateTime RegStartDate { get; set; }
        [Required]
        public DateTime RegEndDate { get; set; }
        public DateTime AdmitCardDate { get; set; }

        public DateTime ExamDate { get; set; }
        public string ExamTime { get; set; }
        public string Venue { get; set; }
        
        public DateTime WrittenTestResult { get; set; }

        public DateTime VivaDate { get; set; }
        public DateTime FinalResult { get; set; }
        
        public DateTime AdmissionDate { get; set; }
        public DateTime AdmissionDateEnd { get; set; }
        public DateTime AdmissionDateWaitingList { get; set; }
        public DateTime ClassStart { get; set; }



        public string Brochure { get; set; }
        public double ExamFee { get; set; }
       
    }
}