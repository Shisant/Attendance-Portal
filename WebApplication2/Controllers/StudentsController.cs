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
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public async Task<ActionResult> Index()
        {
            string sql = "Select * from Students Order By EnrollDate Asc;";

            DataTable dt = db.List(sql);

            var list11 = new Student().List(dt);
            return View(list11);
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,EnrollDate,StudentName,Email,Address,Contact")] Student student)
        {
            if (ModelState.IsValid)
            {
                string sql = "Insert Into Students (EnrollDate, StudentName, Email, Address, Contact) VALUES ('" + student.EnrollDate + "','" + student.StudentName + "','" + student.Email + "','" + student.Address + "','" + student.Contact + "');";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,EnrollDate,StudentName,Email,Address,Contact")] Student student)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update Students SET EnrollDate='" + student.EnrollDate + "',studentName='" + student.StudentName + "',Email='" + student.Email + "',Address='" + student.Address + "',Contact='" + student.Contact + "' Where StudentId='" + student.StudentId + "';";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            string sql = "DELETE FROM Students WHERE StudentId= '" + id + "'";
            db.Delete(sql);
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
