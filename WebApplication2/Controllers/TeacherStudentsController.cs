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
    public class TeacherStudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherStudents
        public ActionResult Index()
        {
            string sql = "Select ts.teacherStudentId, t.teacherId, t.teacherName, s.studentId,s.StudentName from TeacherStudents ts JOIN Students s ON s.studentId = ts.studentId JOIN Staffs t ON t.teacherId= ts.teacherId;";
            DataTable dd = db.List(sql);

            var list1 = new TeacherStudent().List(dd);

            return View(list1);
        }

        // GET: TeacherStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherStudent teacherStudent = db.TeacherStudents.Find(id);
            if (teacherStudent == null)
            {
                return HttpNotFound();
            }
            return View(teacherStudent);
        }

        // GET: TeacherStudents/Create
        public ActionResult Create()
        {
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName");
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName");
            return View();
        }

        // POST: TeacherStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teacherId,studentId")] TeacherStudent teacherStudent)
        {
            if (ModelState.IsValid)
            {
                db.TeacherStudents.Add(teacherStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", teacherStudent.studentId);
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName", teacherStudent.teacherId);
            return View(teacherStudent);
        }

        // GET: TeacherStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherStudent teacherStudent = db.TeacherStudents.Find(id);
            if (teacherStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", teacherStudent.studentId);
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName", teacherStudent.teacherId);
            return View(teacherStudent);
        }

        // POST: TeacherStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teacherId,studentId")] TeacherStudent teacherStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", teacherStudent.studentId);
            ViewBag.teacherId = new SelectList(db.Staffs, "teacherId", "teacherName", teacherStudent.teacherId);
            return View(teacherStudent);
        }

        // GET: TeacherStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherStudent teacherStudent = db.TeacherStudents.Find(id);
            if (teacherStudent == null)
            {
                return HttpNotFound();
            }
            return View(teacherStudent);
        }

        // POST: TeacherStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherStudent teacherStudent = db.TeacherStudents.Find(id);
            db.TeacherStudents.Remove(teacherStudent);
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
