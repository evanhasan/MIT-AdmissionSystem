using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MITAdmissionSystemApp.BLL;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;

namespace MITAdmissionSystemApp.Controllers
{
    public class RegistrationsController : Controller
    {
        private AdmissionContex db = new AdmissionContex();

        // GET: Registrations
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                var AllList = db.Registrations.Where(w=>w.PayStatus==1 && w.ShortList==1).ToList();
                return View(AllList);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Registrations full list
        public ActionResult AllApplicants()
        {
            if (Session["UserId"] != null)
            {
                var AllList = db.Registrations.ToList();
                return View(AllList);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Registrations full list
        public ActionResult RejactedApplicants()
        {
            if (Session["UserId"] != null)
            {
                var AllList = db.Registrations.Where(w=>w.ShortList==0).ToList();
                return View(AllList);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Registration registration = db.Registrations.Find(id);
                if (registration == null)
                {
                    return HttpNotFound();
                }
                return View(registration);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                return View();
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }

        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration registration, HttpPostedFileBase PhotoPath, HttpPostedFileBase SignaturePath, HttpPostedFileBase BachelorCertificatePath)
        {
            string PhotoPath1 = "";
            string SignaturePath1 = "";
            string BachelorCertificatePath1 = "";

            if (ModelState.IsValid)
            {
                Password password = new Password();
                int PasswordStatus = password.CheckStrength(registration.Password);
                //check existing email
                if (PasswordStatus >=4 && db.Registrations.Where(w => w.Email == registration.Email).ToList().Count <= 0)
                {
                    if ((PhotoPath != null && PhotoPath.ContentLength > 0 && PhotoPath.ContentLength < 100000 &&
                         (PhotoPath.ContentType == "image/jpeg" || PhotoPath.ContentType == ".png"))
                        &&
                        (SignaturePath != null && SignaturePath.ContentLength > 0 &&
                         SignaturePath.ContentLength < 80000 &&
                         (SignaturePath.ContentType == "image/jpeg" || BachelorCertificatePath.ContentType == ".png"))
                        && (BachelorCertificatePath != null && BachelorCertificatePath.ContentLength > 0 &&
                            BachelorCertificatePath.ContentLength < 100000 &&
                            (BachelorCertificatePath.ContentType == "image/jpeg" ||
                             BachelorCertificatePath.ContentType == "png")))
                    {
                        //upload photo signature and cirtificate
                        string _PhotoFileName = System.IO.Path.GetFileName(registration.MobileNo + PhotoPath.FileName);
                        var PhotoPath2 = Path.Combine(Server.MapPath("~/Uploads/Registration/"), _PhotoFileName);
                        PhotoPath1 = "Uploads/Registration/" + _PhotoFileName;
                        PhotoPath.SaveAs(PhotoPath2);

                        string _SignatureFileName =
                            System.IO.Path.GetFileName(registration.MobileNo + SignaturePath.FileName);
                        var SignaturePath2 = Path.Combine(Server.MapPath("~/Uploads/Registration/"), _SignatureFileName);
                        SignaturePath1 = "Uploads/Registration/" + _SignatureFileName;
                        SignaturePath.SaveAs(SignaturePath2);

                        string _BachelorFilehName =
                            System.IO.Path.GetFileName(registration.MobileNo + BachelorCertificatePath.FileName);
                        var BachelorCertificatePath2 = Path.Combine(Server.MapPath("~/Uploads/Registration/"),
                            _BachelorFilehName);
                        BachelorCertificatePath1 = "Uploads/Registration/" + _BachelorFilehName;
                        PhotoPath.SaveAs(BachelorCertificatePath2);

                        registration.PhotoPath = PhotoPath1.ToString();
                        registration.SignaturePath = SignaturePath1.ToString();
                        registration.BachelorCertificatePath = BachelorCertificatePath1.ToString();

                        registration.PayStatus = 0;
                        registration.ShortList = 1;
                        registration.Admit = 0;
                        db.Registrations.Add(registration);
                        db.SaveChanges();
                        return RedirectToAction("RegistrationSuccesfull", "Applicant");
                    }
                    else
                    {
                        ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                        ViewBag.ErrorMessage = "Insert Valid type of Photo, Signature and Cirtificate or Password is not strong";
                        return View(registration);
                    }
                }
                else
                {
                    ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                    ViewBag.ErrorMessage = "Email Already registered";
                    return View(registration);
                }
            }
            else
            {
                ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                return View(registration);
            }
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Registration registration = db.Registrations.Find(id);
                if (registration == null)
                {
                    return HttpNotFound();
                }
                return View(registration);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameofApplicant,FatherName,MotherName,Email,ParmanentAddress,Nationality,MobileNo,DateofBirth,SSCSchool,SSCYear,SSCGroup,SSCPoint,HSCCollege,HSCYear,HSCGroup,HSCPoint,BachelorId,BachelorUniversity,BachelorYear,BachelorGrade,MasterUniversity,MasterrYear,MasterGrade")] Registration registration)
        {
            if (Session["UserId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(registration).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(registration);
               
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Registration registration = db.Registrations.Find(id);
                if (registration == null)
                {
                    return HttpNotFound();
                }
                return View(registration);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserId"] != null)
            {
                Registration registration = db.Registrations.Find(id);
                db.Registrations.Remove(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }


        //it will let to see about Deletion  Jquery Json
        public JsonResult DeleteApplicantFromListByClick(int Id)
        {
            Registration registration = db.Registrations.Find(Id);
            registration.ShortList = 0;
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);

        }

        //it will let to see about Deletion  Jquery Json
        public JsonResult RestoreApplicantByClick(int Id)
        {
            Registration registration = db.Registrations.Find(Id);
            registration.ShortList = 1;
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);

        }


        //it will let to View about Applicant  Jquery Json
        public JsonResult ViewApplicantByClick(int Id)
        {
            Registration registration = db.Registrations.Find(Id);

            return Json(registration, JsonRequestBehavior.AllowGet);

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
