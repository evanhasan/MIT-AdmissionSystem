using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MITAdmissionSystemApp.Models
{
    public class Payment
    {
        [Key]
        public int Id{ get; set; }
         [Required]
        public int ApplicantId { get; set; }
        [Required]
        public int TrxId { get; set; }
        public DateTime DateTime { get; set; }
    }
}