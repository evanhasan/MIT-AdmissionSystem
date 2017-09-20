using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;

namespace MITAdmissionSystemApp.Controllers
{
    public class PaymentController : Controller
    {
        private AdmissionContex db = new AdmissionContex();
        //it will let to see about paid Applicant
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                var PaidList = db.Registrations.Where(w => w.TrxId > 0 && w.PayStatus==0).ToList();
                return View(PaidList);
            }
            else
            {
                return RedirectToAction("LoginMaster","Admins");
            }
        }


        //it will let to see about Confirm paid Applicant
        public ActionResult ConfirmPaidApplicant()
        {
            if (Session["UserId"] != null)
            {
                var PaidList = db.Registrations.Where(w => w.PayStatus == 1 && w.TrxId>0).ToList();
                return View(PaidList);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        //it will let to see about unpaid Applicant
        public ActionResult UnPaidApplicant()
        {
            if (Session["UserId"] != null)
            {

                var unPaidList = db.Registrations.Where(w => w.TrxId <=0).ToList();
                return View(unPaidList);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }



        //it will let to see about Confirm paid Applicant  Jquery Json
        public JsonResult ConfirmPaymentByClick(int Id)
        {
            Registration registration = db.Registrations.Find(Id);
            registration.PayStatus = 1;
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);

        }


        //it will let to see about UnConfirm paid Applicant  Jquery Json
        public JsonResult UnConfirmPaymentByClick(int Id)
        {
            Registration registration = db.Registrations.Find(Id);
            registration.PayStatus = 0;
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);

        }


        //it will let to see about Trxid missmatch Applicant  Jquery Json
        public JsonResult MissMatchPaymentByClick(int Id)
        {
            Registration registration = db.Registrations.Find(Id);
            registration.TrxId = 0;
            db.SaveChanges();
            return Json("", JsonRequestBehavior.AllowGet);

        }

    }
}