using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingApplication.DAL;
using TrainingApplication.Models;

namespace TrainingApplication.Controllers
{
    public class NewUserRegistrationController : Controller
    {
        private Programinfo db = new Programinfo();

        // GET: NewUserRegistration
        public ActionResult Index()
        {
            return View(db.newUserRegistrations.ToList());
        }

        // GET: NewUserRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserRegistration newUserRegistration = db.newUserRegistrations.Find(id);
            if (newUserRegistration == null)
            {
                return HttpNotFound();
            }
            return View(newUserRegistration);
        }
        
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(NewUserRegistration reg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.newUserRegistrations
                               where userlist.Username == reg.Username && userlist.Password == reg.Password
                               select new
                               {
                                   userlist.UserId,
                                   userlist.Username
                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    Session["UserId"] = details.FirstOrDefault().UserId;
                    Session["Username"] = details.FirstOrDefault().Username;
                    return RedirectToAction("welcome");
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(reg);
        }
        public ActionResult welcome()
        {
            return View();

        }
        // GET: NewUserRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewUserRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password,ConfirmPassword,Email,CreatedDate,LastLoginDate")] NewUserRegistration newUserRegistration)
        {
            if (ModelState.IsValid)
            {
                db.newUserRegistrations.Add(newUserRegistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newUserRegistration);
        }

        // GET: NewUserRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserRegistration newUserRegistration = db.newUserRegistrations.Find(id);
            if (newUserRegistration == null)
            {
                return HttpNotFound();
            }
            return View(newUserRegistration);
        }

        // POST: NewUserRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username,Password,ConfirmPassword,Email,CreatedDate,LastLoginDate")] NewUserRegistration newUserRegistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUserRegistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUserRegistration);
        }

        // GET: NewUserRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUserRegistration newUserRegistration = db.newUserRegistrations.Find(id);
            if (newUserRegistration == null)
            {
                return HttpNotFound();
            }
            return View(newUserRegistration);
        }

        // POST: NewUserRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewUserRegistration newUserRegistration = db.newUserRegistrations.Find(id);
            db.newUserRegistrations.Remove(newUserRegistration);
            db.SaveChanges();
            return RedirectToAction("Index");
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
