using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RoutinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Routines
        public ActionResult Index()
        {
            var routines = db.Routines.Include(r => r.ClassFK).Include(r => r.courseFK).Include(r => r.timetableFK);
            return View(routines.ToList());
        }

        // GET: Routines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // GET: Routines/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.ClassDetails, "ClassId", "ClassName");
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time");
            return View();
        }

        // POST: Routines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,timeTableId,courseId")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Routines.Add(routine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassDetails, "ClassId", "ClassName", routine.ClassId);
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", routine.courseId);
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time", routine.timeTableId);
            return View(routine);
        }

        // GET: Routines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassDetails, "ClassId", "ClassName", routine.ClassId);
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", routine.courseId);
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time", routine.timeTableId);
            return View(routine);
        }

        // POST: Routines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,timeTableId,courseId")] Routine routine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassDetails, "ClassId", "ClassName", routine.ClassId);
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", routine.courseId);
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time", routine.timeTableId);
            return View(routine);
        }

        // GET: Routines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routine routine = db.Routines.Find(id);
            if (routine == null)
            {
                return HttpNotFound();
            }
            return View(routine);
        }

        // POST: Routines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Routine routine = db.Routines.Find(id);
            db.Routines.Remove(routine);
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
