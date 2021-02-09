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
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groups
        public ActionResult Index()
        {
            string sql = "Select g.GroupId, g.GroupName, f.FacultyId, f.Name, s.studentId,s.StudentName,s.EnrollDate from Groups g JOIN Students s ON s.studentId = g.studentId JOIN Faculties f ON f.FacultyId= g.FacultyId;";
            DataTable dd = db.List(sql);

            var list1 = new Groups().List(dd);

            return View(list1);
            //var groups = db.Groups.Include(g => g.facultyCodeFK).Include(g => g.studentCode);
            //return View(groups.ToList());
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.Groups.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupName,StudentId,FacultyId")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(groups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name", groups.FacultyId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", groups.StudentId);
            return View(groups);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.Groups.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name", groups.FacultyId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", groups.StudentId);
            return View(groups);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName,StudentId,FacultyId")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "Name", groups.FacultyId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", groups.StudentId);
            return View(groups);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Groups groups = db.Groups.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Groups groups = db.Groups.Find(id);
            db.Groups.Remove(groups);
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
