using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;
using Rotativa;

namespace MITAdmissionSystemApp.Controllers
{
    public class AdmitController : Controller
    {
        private AdmissionContex db = new AdmissionContex();
        // GET: Admit
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.SelectedListForAdmission = db.Registrations.Where(x => x.Admit == 1).ToList();

                return View();
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }
        //by click produce admit card =1 and roll number will bw updated randomly
        public ActionResult ProduceAdmit()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }
        [HttpPost]
        public ActionResult ProduceAdmit(string Password)
        {
            if (Session["UserId"] != null)
            {
                int user = Convert.ToInt32(Session["UserId"]);
                int count = db.Admins.Count(x => x.UserId == user && x.Password == Password);

                if (count > 0)
                {
                    List<Registration> Selected = db.Registrations.Where(x => x.ShortList == 1 && x.PayStatus == 1).ToList();
                    int CountApplicant = Selected.Count();

                    Random r = new Random();
                    List<int> Numberlist = new List<int>();
                    while (Numberlist.Count < CountApplicant)
                    {

                        int rInt = r.Next(100, CountApplicant + 100); //for ints
                        if (Numberlist.Contains(rInt) == false)
                        {
                            Numberlist.Add(rInt);
                        }
                    }
                    int i = 0;

                    //Update Admit status 0 for all and then only selected applicant will updated admit =1
                    var FullList = db.Registrations.ToList();
                    FullList.ForEach(x=>x.Admit=0);
                    db.SaveChanges();

                    //Admit updated here
                    foreach (Registration registration in Selected)
                    {
                        registration.Admit = 1;
                        int RandomRoll = Numberlist[i];
                        registration.RollNumber = RandomRoll;
                        db.SaveChanges();
                        i++;
                    }
                    ViewBag.Message = "Admit Card Produced and Roll Number is Updated";
                }
                return View();
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }
        public ActionResult AdmitCard()
        {
            return View();
        }
        //show in web page for applicant 
        public ActionResult AdmitForApplicant()
        {
            int Id = Convert.ToInt32(Session["ApplicantId"]);
            List<Registration> Info = db.Registrations.Where(x => x.Id == Id && x.Admit == 1).ToList();
            int Count = Info.Count();
            //ViewBag.info = Info.FirstOrDefault();
            if (Count > 0)
            {
                ViewBag.NameofAdmission = db.Settings.Select(x=>x.ExamName).ToList().LastOrDefault();

                Registration info2 = Info.FirstOrDefault();
                ViewBag.Id = Id;
                ViewBag.Message = "Admit card have already produced click the following button for download";
                ViewBag.count = Count;
                return View(info2);
            }

            ViewBag.Message = "Admit card is not produced yet";
            return View();

        }

        //download pdf copy of individual
        public ActionResult AdmitForApplicant2(Registration info)
        {
            ViewBag.NameofAdmission = db.Settings.Select(x => x.ExamName).ToList().LastOrDefault();
            return View(info);
        }

        //PDF Generetor Action individual
        public ActionResult DownloadAdmit(int Id)
        {
            var Info = db.Registrations.Where(x => x.Id == Id && x.Admit == 1);
            Registration info = Info.FirstOrDefault();
            return new ActionAsPdf("AdmitForApplicant2", info)
            {
                FileName = "~/DownloadPdf/Admit" + Session["ApplicantId"] + ".pdf"
            };
        }
        //PDF Generetor Action for list
        public ActionResult DownloadListofApplicant()
        {
            return new ActionAsPdf("AdmitListPdf")
            {
                FileName = "~/DownloadPdf/AdmitList.pdf"
            };
        }
        //generate PDF list of Applicant Admit
        public ActionResult AdmitListPdf()
        {
            ViewBag.SelectedListForAdmission = db.Registrations.Where(x => x.Admit == 1).ToList();

            return View();
        }
    }
}