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
    public class CreateNewTrainingProgramController : Controller
    {
        private Programinfo db = new Programinfo();

        // GET: CreateNewTrainingProgram
        public ViewResult Index()
        {
            return View(db.createNewTrainingPrograms.ToList());
        }

        // GET: CreateNewTrainingProgram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewTrainingProgram createNewTrainingProgram = db.createNewTrainingPrograms.Find(id);
            if (createNewTrainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(createNewTrainingProgram);
        }

        // GET: CreateNewTrainingProgram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateNewTrainingProgram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trainingID,topic,description,date,startTime,endTime,trainerName,attendeeLimit")] CreateNewTrainingProgram createNewTrainingProgram)
        {
            if (ModelState.IsValid)
            {
                db.createNewTrainingPrograms.Add(createNewTrainingProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(createNewTrainingProgram);
        }

        // GET: CreateNewTrainingProgram/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewTrainingProgram createNewTrainingProgram = db.createNewTrainingPrograms.Find(id);
            if (createNewTrainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(createNewTrainingProgram);
        }

        // POST: CreateNewTrainingProgram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trainingID,topic,description,date,startTime,endTime,trainerName,attendeeLimit")] CreateNewTrainingProgram createNewTrainingProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createNewTrainingProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(createNewTrainingProgram);
        }

        // GET: CreateNewTrainingProgram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateNewTrainingProgram createNewTrainingProgram = db.createNewTrainingPrograms.Find(id);
            if (createNewTrainingProgram == null)
            {
                return HttpNotFound();
            }
            return View(createNewTrainingProgram);
        }

        // POST: CreateNewTrainingProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateNewTrainingProgram createNewTrainingProgram = db.createNewTrainingPrograms.Find(id);
            db.createNewTrainingPrograms.Remove(createNewTrainingProgram);
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
