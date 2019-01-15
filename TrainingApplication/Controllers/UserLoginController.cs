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
    public class UserLoginController : Controller
    {
        private Programinfo db = new Programinfo();

        // GET: UserLogin
        //public ActionResult Index()
        //{
        //    return View(db.UserLogins.ToList());
        //}
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(UserLogin reg)
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
                    return RedirectToAction("wellcomeAdmin");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(reg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserLogin reg)
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
                    return RedirectToAction("wellcome");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(reg);
        }
        public ActionResult wellcome()
        {
            return View();

        }
        public ActionResult wellcomeAdmin()
        {
            return View();

        }
        // GET: UserLogin/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserLogin userLogin = db.UserLogins.Find(id);
        //    if (userLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userLogin);
        //}

        //// GET: UserLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username,Password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.UserLogins.Add(userLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userLogin);
        }

        //// GET: UserLogin/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserLogin userLogin = db.UserLogins.Find(id);
        //    if (userLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userLogin);
        //}

        //// POST: UserLogin/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserId,Username,Password")] UserLogin userLogin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(userLogin).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(userLogin);
        //}

        //// GET: UserLogin/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserLogin userLogin = db.UserLogins.Find(id);
        //    if (userLogin == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userLogin);
        //}

        //// POST: UserLogin/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    UserLogin userLogin = db.UserLogins.Find(id);
        //    db.UserLogins.Remove(userLogin);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
