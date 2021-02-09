using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendances
        public async Task<ActionResult> Index()
        {
            string sql = "Select a.attendenceId, a.AttendDate, a.attendenceRemark, t.timeTableId, t.time, s.studentId, s.StudentName, c.courseId, c.courseName from Attendances a JOIN Students s ON s.studentId = a.studentId JOIN Courses c ON c.courseId= a.courseId JOIN Timetables t ON t.timeTableId= a.timeTableId;";
            DataTable dd = db.List(sql);

            var list1 = new Attendance().List(dd);

            return View(list1);
        }

        // GET: Attendances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = await db.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "courseId", "courseName");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "attendenceId,AttendDate,attendenceRemark,timeTableId,StudentId,CourseId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "courseId", "courseName", attendance.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", attendance.StudentId);
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time", attendance.timeTableId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = await db.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "courseId", "courseName", attendance.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", attendance.StudentId);
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time", attendance.timeTableId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "attendenceId,AttendDate,attendenceRemark,timeTableId,StudentId,CourseId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "courseId", "courseName", attendance.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", attendance.StudentId);
            ViewBag.timeTableId = new SelectList(db.Timetables, "timeTableId", "time", attendance.timeTableId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = await db.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Attendance attendance = await db.Attendances.FindAsync(id);
            db.Attendances.Remove(attendance);
            await db.SaveChangesAsync();
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
