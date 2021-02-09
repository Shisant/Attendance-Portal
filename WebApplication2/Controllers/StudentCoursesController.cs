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
    public class StudentCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentCourses
        public ActionResult Index()
        {
            //string sql = "Select sc.studentCourseId, c.courseId, c.courseName, s.studentId,s.StudentName,s.EnrollDate,s.Email,s.Address,s.Contact from StudentCourses sc JOIN Students s ON s.studentId = sc.studentId JOIN Courses c ON c.courseId= sc.courseId Order By s.EnrollDate ASC;";
            //DataTable dd = db.List(sql);
            //var list1 = new StudentCourse().List(dd);
            //return View(list1);
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            var studentCourses = db.StudentCourses.Include(s => s.courseIdFK).Include(s => s.studentIdFK);
            return View(studentCourses.ToList());
        }
        [HttpPost]
        public ActionResult Index(int courseId)
        {
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName");
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            var studentCourses = db.StudentCourses.Include(s => s.courseIdFK).Include(s => s.studentIdFK).Where(a => a.courseId == courseId);
            return View(studentCourses.ToList());
        }

        // GET: StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName");
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentId,courseId")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", studentCourse.courseId);
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", studentCourse.studentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", studentCourse.courseId);
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", studentCourse.studentId);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,courseId")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseId = new SelectList(db.Courses, "courseId", "courseName", studentCourse.courseId);
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", studentCourse.studentId);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            db.StudentCourses.Remove(studentCourse);
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
