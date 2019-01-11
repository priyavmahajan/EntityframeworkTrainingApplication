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
    public class CreateNewMeetingProgramController : Controller
    {
        private Programinfo db = new Programinfo();

        // GET: CreateNewMeetingProgram
        public ActionResult Index()
        {
            return View(db.createNewMeetingPrograms.ToList());
        }

        // GET: CreateNewMeetingProgram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewMeetingProgram createNewMeetingProgram = db.createNewMeetingPrograms.Find(id);
            if (createNewMeetingProgram == null)
            {
                return HttpNotFound();
            }
            return View(createNewMeetingProgram);
        }

        // GET: CreateNewMeetingProgram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateNewMeetingProgram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "meetingID,topic,description,date,startTime,endTime,trainerName,attendeeLimit")] CreateNewMeetingProgram createNewMeetingProgram)
        {
            if (ModelState.IsValid)
            {
                db.createNewMeetingPrograms.Add(createNewMeetingProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createNewMeetingProgram);
        }

        

        // GET: CreateNewMeetingProgram/Edit/5
        public ActionResult Edit(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           CreateNewMeetingProgram createNewMeetingProgram = db.createNewMeetingPrograms.Find(id);
            if (createNewMeetingProgram == null)
            {
                return HttpNotFound();
            }
            return View(createNewMeetingProgram);
        }

        // POST: CreateNewMeetingProgram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "meetingID,topic,description,date,startTime,endTime,trainerName,attendeeLimit")] CreateNewMeetingProgram createNewMeetingProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createNewMeetingProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createNewMeetingProgram);
        }

        // GET: CreateNewMeetingProgram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewMeetingProgram createNewMeetingProgram = db.createNewMeetingPrograms.Find(id);
            if (createNewMeetingProgram == null)
            {
                return HttpNotFound();
            }
            return View(createNewMeetingProgram);
        }

        // POST: CreateNewMeetingProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateNewMeetingProgram createNewMeetingProgram = db.createNewMeetingPrograms.Find(id);
            db.createNewMeetingPrograms.Remove(createNewMeetingProgram);
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
