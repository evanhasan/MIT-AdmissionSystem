using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;

namespace MITAdmissionSystemApp.Controllers
{
    public class SettingsController : Controller
    {
        private AdmissionContex db = new AdmissionContex();

        // GET: Settings
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return View(db.Settings.ToList());
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Settings/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Settings settings = db.Settings.Find(id);
                if (settings == null)
                {
                    return HttpNotFound();
                }
                return View(settings);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Settings/Create
        public ActionResult Create()
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

        // POST: Settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Settings settings, HttpPostedFileBase Brochure)
        {
            if (Session["UserId"] != null)
            {
                if (ModelState.IsValid)
                {
                    string BrochurePath = "";
                    string BrochurePath2 = "";

                    if (Brochure != null && Brochure.ContentLength > 0)
                    {
                        string _FileName = System.IO.Path.GetFileName(Brochure.FileName);

                        BrochurePath = Path.Combine(Server.MapPath("~/Uploads/Settings/"), _FileName);
                        BrochurePath2 = "Uploads/Settings/" + _FileName;

                        Brochure.SaveAs(BrochurePath);
                        settings.Brochure = BrochurePath2;

                        db.Settings.Add(settings);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                  
                }

                return View(settings);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }


        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Settings settings = db.Settings.Find(id);
                if (settings == null)
                {
                    return HttpNotFound();
                }
                return View(settings);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // POST: Settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Settings settings)
        {
            if (Session["UserId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(settings).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(settings);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Settings settings = db.Settings.Find(id);
                if (settings == null)
                {
                    return HttpNotFound();
                }
                return View(settings);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserId"] != null)
            {
                Settings settings = db.Settings.Find(id);
                db.Settings.Remove(settings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
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
