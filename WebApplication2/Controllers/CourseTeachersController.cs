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
    public class CourseTeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseTeachers
        public ActionResult Index()
        {
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            var courseTeachers = db.CourseTeachers.Include(c => c.courseIdFk).Include(c => c.teacherIdFK);
            return View(courseTeachers.ToList());
        }
        [HttpPost]
        public ActionResult Index(int courseId)
        {
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            var courseTeachers = db.CourseTeachers.Include(c => c.courseIdFk).Include(c => c.teacherIdFK).Where(a => a.courseId == courseId); ;
            return View(courseTeachers.ToList());
        }

        // GET: CourseTeachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTeacher courseTeacher = db.CourseTeachers.Find(id);
            if (courseTeacher == null)
            {
                return HttpNotFound();
            }
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Create
        public ActionResult Create()
        {
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName");
            return View();
        }

        // POST: CourseTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "courseTeacherId,courseId,teacherId")] CourseTeacher courseTeacher)
        {
            if (ModelState.IsValid)
            {
                db.CourseTeachers.Add(courseTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", courseTeacher.courseId);
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName", courseTeacher.teacherId);
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTeacher courseTeacher = db.CourseTeachers.Find(id);
            if (courseTeacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", courseTeacher.courseId);
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName", courseTeacher.teacherId);
            return View(courseTeacher);
        }

        // POST: CourseTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "courseTeacherId,courseId,teacherId")] CourseTeacher courseTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseTeacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", courseTeacher.courseId);
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName", courseTeacher.teacherId);
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseTeacher courseTeacher = db.CourseTeachers.Find(id);
            if (courseTeacher == null)
            {
                return HttpNotFound();
            }
            return View(courseTeacher);
        }

        // POST: CourseTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseTeacher courseTeacher = db.CourseTeachers.Find(id);
            db.CourseTeachers.Remove(courseTeacher);
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
