using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MITAdmissionSystemApp.BLL;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;

namespace MITAdmissionSystemApp.Controllers
{
    public class AdminsController : Controller
    {
        private AdmissionContex db = new AdmissionContex();

        // GET: Admins
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return View(db.Admins.ToList());

            }
            else
            {
                return RedirectToAction("LoginMaster");
            }
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            else
            {
                return RedirectToAction("LoginMaster");
            }
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginMaster");
            }
        }

        // POST: Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,Email,Designation,PhoneNo,Password,ConfirmPassword")] Admin admin)
        {
            Password password = new Password();
            int PasswordStatus = password.CheckStrength(admin.Password);
            if (ModelState.IsValid && PasswordStatus>=4)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);

            }
            else
            {
                return RedirectToAction("LoginMaster");
            }
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,Email,Designation,PhoneNo,Password,ConfirmPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Admin admin = db.Admins.Find(id);
                if (admin == null)
                {
                    return HttpNotFound();
                }
                return View(admin);
            }
            else
            {
                return RedirectToAction("LoginMaster");
            }

        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //login Action
        public ActionResult LoginMaster()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginMaster(Admin user)
        {

            Admin DB = new Admin();

            if (user.Email != null && user.Password != null)
            {
                var Master = db.Admins.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (Master != null)
                {
                    Session["Email"] = Master.Email.ToString();
                    Session["UserId"] = Master.UserId.ToString();
                    return RedirectToAction("MasterPage");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password not matched");

                }
            }
            return View();

        }
        //Dashboard master
        public ActionResult MasterPage()
        {
            if (Session["UserId"] != null)
            {
                ViewBag.AllCount = db.Registrations.Count();
                ViewBag.Paid = db.Registrations.Count(x=>x.PayStatus==1);
                ViewBag.unpaid = db.Registrations.Count(x => x.PayStatus == 0);
                ViewBag.rejected = db.Registrations.Count(y => y.ShortList == 0);
                 
                return View();
            }
            else
            {
                return RedirectToAction("LoginMaster");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("LoginMaster", "Admins");
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
