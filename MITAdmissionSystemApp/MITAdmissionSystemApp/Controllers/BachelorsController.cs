using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MITAdmissionSystemApp.Models;
using MITAdmissionSystemApp.Models.Contex;

namespace MITAdmissionSystemApp.Controllers
{
    public class BachelorsController : Controller
    {
        private AdmissionContex db = new AdmissionContex();

        // GET: Bachelors
        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {
                return View(db.Bachelors.ToList());
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Bachelors/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bachelor bachelor = db.Bachelors.Find(id);
                if (bachelor == null)
                {
                    return HttpNotFound();
                }
                return View(bachelor);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Bachelors/Create
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

        // POST: Bachelors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Digree,Decription")] Bachelor bachelor)
        {
            if (Session["UserId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Bachelors.Add(bachelor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(bachelor);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Bachelors/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bachelor bachelor = db.Bachelors.Find(id);
                if (bachelor == null)
                {
                    return HttpNotFound();
                }
                return View(bachelor);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // POST: Bachelors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Digree,Decription")] Bachelor bachelor)
        {
            if (Session["UserId"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bachelor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bachelor);
            }
            else
            {
                return RedirectToAction("LoginMaster", "Admins");
            }
        }

        // GET: Bachelors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserId"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bachelor bachelor = db.Bachelors.Find(id);
                if (bachelor == null)
                {
                    return HttpNotFound();
                }
                return View(bachelor);
            }
            else
            {
                return RedirectToAction("LoginMaster","Admins");
            }
        }

        // POST: Bachelors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            if (Session["UserId"] != null)
            {
                Bachelor bachelor = db.Bachelors.Find(id);
                db.Bachelors.Remove(bachelor);
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
