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
    public class StudentFacultiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentFaculties
        public async Task<ActionResult> Index()
        {
            string sql = "Select sf.studentFacultyId, f.facultyId, f.Name, s.studentId, s.StudentName, s.EnrollDate from StudentFaculties sf JOIN Students s ON s.studentId = sf.studentId JOIN Faculties f ON f.facultyId= sf.facultyId Order By s.EnrollDate;";
            DataTable dd = db.List(sql);

            var list1 = new StudentFaculty().List(dd);

            return View(list1);
        }

        // GET: StudentFaculties/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFaculty studentFaculty = await db.StudentFaculties.FindAsync(id);
            if (studentFaculty == null)
            {
                return HttpNotFound();
            }
            return View(studentFaculty);
        }

        // GET: StudentFaculties/Create
        public ActionResult Create()
        {
            ViewBag.facultyId = new SelectList(db.Faculties, "FacultyId", "Name");
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: StudentFaculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "studentFacultyId,facultyId,studentId")] StudentFaculty studentFaculty)
        {
            if (ModelState.IsValid)
            {
                db.StudentFaculties.Add(studentFaculty);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.facultyId = new SelectList(db.Faculties, "FacultyId", "Name", studentFaculty.facultyId);
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", studentFaculty.studentId);
            return View(studentFaculty);
        }

        // GET: StudentFaculties/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFaculty studentFaculty = await db.StudentFaculties.FindAsync(id);
            if (studentFaculty == null)
            {
                return HttpNotFound();
            }
            ViewBag.facultyId = new SelectList(db.Faculties, "FacultyId", "Name", studentFaculty.facultyId);
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", studentFaculty.studentId);
            return View(studentFaculty);
        }

        // POST: StudentFaculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "studentFacultyId,facultyId,studentId")] StudentFaculty studentFaculty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentFaculty).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.facultyId = new SelectList(db.Faculties, "FacultyId", "Name", studentFaculty.facultyId);
            ViewBag.studentId = new SelectList(db.Students, "StudentId", "StudentName", studentFaculty.studentId);
            return View(studentFaculty);
        }

        // GET: StudentFaculties/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentFaculty studentFaculty = await db.StudentFaculties.FindAsync(id);
            if (studentFaculty == null)
            {
                return HttpNotFound();
            }
            return View(studentFaculty);
        }

        // POST: StudentFaculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentFaculty studentFaculty = await db.StudentFaculties.FindAsync(id);
            db.StudentFaculties.Remove(studentFaculty);
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
