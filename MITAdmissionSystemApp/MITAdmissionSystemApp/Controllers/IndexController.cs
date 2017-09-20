using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MITAdmissionSystemApp.Models.Contex;

namespace MITAdmissionSystemApp.Controllers
{
    public class IndexController : Controller
    {
        AdmissionContex db=new AdmissionContex();
        // GET: Index
        public ActionResult Index()
        {
            var ExamInfo = db.Settings.ToList().LastOrDefault();
            return View(ExamInfo);
        }
    }
}