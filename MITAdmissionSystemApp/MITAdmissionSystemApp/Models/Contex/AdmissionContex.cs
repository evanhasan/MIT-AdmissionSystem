using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MITAdmissionSystemApp.Models.Contex
{
    public class AdmissionContex:DbContext
    {
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Bachelor> Bachelors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Settings> Settings { get; set; } 
    }
}