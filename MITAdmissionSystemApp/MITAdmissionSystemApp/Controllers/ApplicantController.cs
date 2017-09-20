using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using MITAdmissionSystemApp.BLL;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;
using SRVTextToImage;

namespace MITAdmissionSystemApp.Controllers
{
    public class ApplicantController : Controller
    {
        private AdmissionContex db = new AdmissionContex();
        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }


        // GET: Registrations/Create
        public ActionResult Registration()
        {
            ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Registration registration, HttpPostedFileBase PhotoPath, HttpPostedFileBase SignaturePath, HttpPostedFileBase BachelorCertificatePath)
        {
            // Session["CaptchaImageText"].ToString() == CaptchaText
            if (true)
            {
                string PhotoPath1 = "";
                string SignaturePath1 = "";
                string BachelorCertificatePath1 = "";

                if (true)
                {
                    //password test is it strong or not
                    Password password = new Password();
                    int PasswordStatus = password.CheckStrength(registration.Password);
                    if (PasswordStatus >= 4)
                    {
                        //check existing email 
                        if (db.Registrations.Where(w => w.Email == registration.Email).ToList().Count <= 0)
                        {
                            if ((PhotoPath != null && PhotoPath.ContentLength > 0 && PhotoPath.ContentLength < 100000 )
                                &&
                                (SignaturePath != null && SignaturePath.ContentLength > 0 &&
                                 SignaturePath.ContentLength < 80000)
                                && (BachelorCertificatePath != null && BachelorCertificatePath.ContentLength > 0 &&
                                    BachelorCertificatePath.ContentLength < 200000 ))
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
                                BachelorCertificatePath.SaveAs(BachelorCertificatePath2);

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
                                ViewBag.ErrorMessage = "***Insert Valid type of Photo, Signature and Certificate";
                                return View(registration);
                            }
                        }
                        else
                        {
                            ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                            ViewBag.ErrorMessage = "***Email Already registered";
                            return View(registration);
                        }
                    }
                    else
                    {
                        ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                        ViewBag.ErrorMessage = "***Password is not complex enough .";
                        return View();
                    }

                }
                else
                {
                    ViewBag.Bachelors = new SelectList(db.Bachelors, "Id", "Digree");
                    ViewBag.ErrorMessage = "***Input data is not enough";
                    return View(registration);
                }
            }
            else
            {
                ViewBag.Message = "Captcha Validation Failed!";
                return View();
            }


        }

        public ActionResult RegistrationSuccesfull()
        {
            return View();

        }

        //login Action
        public ActionResult ApplicantLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplicantLogin(Registration user)
        {

            if (user.Email != null && user.Password != null)
            {
                var Applicant = db.Registrations.Where(x => x.Email == user.Email && x.Password == user.Password).ToList().FirstOrDefault();
                if (Applicant != null)
                {
                    Session["Email"] = Applicant.Email.ToString();
                    Session["ApplicantId"] = Applicant.Id.ToString();
                    return RedirectToAction("ApplicantDashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password not matched");

                }
            }
            return View();
        }

        //when Applicant will click payment button the it will show
        public ActionResult Payment()
        {
            if (Session["ApplicantId"] != null)
            {
                int ApplicantId = Convert.ToInt32(Session["ApplicantId"]);
                var Applicant = db.Registrations.Where(x => x.Id == ApplicantId).FirstOrDefault();

                if (Applicant.PayStatus == 0 && Applicant.TrxId == 0)
                {
                    ViewBag.ApplicantId = ApplicantId;
                    return View();
                }
                else if (Applicant.TrxId > 0 && Applicant.PayStatus == 1)
                {

                    var ApplicantInfo = db.Registrations.Where(x => x.Id == ApplicantId).FirstOrDefault();
                    ViewBag.ApplicantInfo = ApplicantInfo;
                    return View("IsPaid");
                }
                else
                {
                    var ApplicantName = db.Registrations.Where(x => x.Id == ApplicantId).Select(x => x.NameofApplicant).FirstOrDefault();
                    ViewBag.ApplicantInfo = ApplicantName;
                    return View("PaymentWaiting");
                }

            }
            else
            {
                return RedirectToAction("ApplicantLogin", "Applicant");
            }
        }

        [HttpPost]
        public ActionResult Payment(Payment _Payment)
        {
            if (Session["ApplicantId"] != null)
            {
                if (ModelState.IsValid)
                {
                    int ApplicantId = Convert.ToInt32(Session["ApplicantId"]);
                    var PayStatus = db.Registrations.Where(x => x.Id == ApplicantId).FirstOrDefault();
                    PayStatus.TrxId = _Payment.TrxId;
                    db.SaveChanges();
                    return View("PaymentWaiting");
                }
                else
                {
                    return View(_Payment);
                }

            }
            else
            {
                return RedirectToAction("ApplicantLogin", "Applicant");
            }
        }

        //if paid the this view will show paid
        public ActionResult PaymentWaiting()
        {
            if (Session["ApplicantId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ApplicantLogin", "Applicant");
            }
        }

        //if paid the this view will show paid
        public ActionResult IsPaid()
        {
            if (Session["ApplicantId"] != null)
            {

                return View();

            }
            else
            {
                return RedirectToAction("ApplicantLogin", "Applicant");
            }
        }


        //Dashboard master
        public ActionResult ApplicantDashboard()
        {
            if (Session["ApplicantId"] != null)
            {
                int ApplicantId = Convert.ToInt32(Session["ApplicantId"]);
                var Applicant = db.Registrations.Where(x => x.Id == ApplicantId).FirstOrDefault();
                return View(Applicant);
            }
            else
            {
                return RedirectToAction("ApplicantLogin", "Applicant");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("ApplicantLogin", "Applicant");
        }

        // This action for get Captcha Image
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")] // This is for output cache false
        public FileResult GetCaptchaImage()
        {
            CaptchaRandomImage CI = new CaptchaRandomImage();
            this.Session["CaptchaImageText"] = CI.GetRandomString(5); // here 5 means I want to get 5 char long captcha
            //CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75);
            // Or We can use another one for get custom color Captcha Image 
            CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75, Color.DarkGray, Color.White);
            MemoryStream stream = new MemoryStream();
            CI.Image.Save(stream, ImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(stream, "image/png");
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