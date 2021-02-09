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
    public class ClassDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassDetails
        public ActionResult Index()
        {

            string sql = "Select * from ClassDetails;";

            DataTable dt = db.List(sql);

            var list11 = new ClassDetails().List(dt);
            return View(list11);

        }

        // GET: ClassDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetails classDetails = db.ClassDetails.Find(id);
            if (classDetails == null)
            {
                return HttpNotFound();
            }
            return View(classDetails);
        }

        // GET: ClassDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName,Year,Semester")] ClassDetails classDetails)
        {
            if (ModelState.IsValid)
            {
                string sql = "Insert Into ClassDetails(ClassName,Year,Semester) VALUES ('" + classDetails.ClassName + "','" + classDetails.Year + "','" + classDetails.Semester + "');";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(classDetails);
        }

        // GET: ClassDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetails classDetails = db.ClassDetails.Find(id);
            if (classDetails == null)
            {
                return HttpNotFound();
            }
            return View(classDetails);
        }

        // POST: ClassDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName,Year,Semester")] ClassDetails classDetails)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update ClassDetails SET ClassName='" + classDetails.ClassName + "',Year='" + classDetails.Year + "',Semester='" + classDetails.Semester + "' Where ClassId='" + classDetails.ClassId + "';";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(classDetails);
        }

        // GET: ClassDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetails classDetails = db.ClassDetails.Find(id);
            if (classDetails == null)
            {
                return HttpNotFound();
            }
            return View(classDetails);
        }

        // POST: ClassDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "DELETE FROM ClassDetails WHERE ClassId= '" + id + "'";
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
