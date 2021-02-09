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
    public class TimetablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Timetables
        public async Task<ActionResult> Index()
        {
            string sql = "Select * from Timetables;";

            DataTable dt = db.List(sql);

            var list11 = new Timetable().List(dt);
            return View(list11);
        }

        // GET: Timetables/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = await db.Timetables.FindAsync(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // GET: Timetables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timetables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "timeTableId,time,room,classDuration")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                string sql = "Insert Into Timetables (time,room,classDuration) VALUES ('" + timetable.time  + "','" + timetable.room + "','" + timetable.classDuration + "');";
                db.Create(sql);
                return RedirectToAction("Index");
            }

            return View(timetable);
        }

        // GET: Timetables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = await db.Timetables.FindAsync(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "timeTableId,time,room,classDuration")] Timetable timetable)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update Timetables SET time='" + timetable.time + "',room='" + timetable.room + "',classDuration='" + timetable.classDuration + "' Where timeTableId='" + timetable.timeTableId + "';";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(timetable);
        }

        // GET: Timetables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timetable timetable = await db.Timetables.FindAsync(id);
            if (timetable == null)
            {
                return HttpNotFound();
            }
            return View(timetable);
        }

        // POST: Timetables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            string sql = "DELETE FROM Timetables WHERE timeTableId= '" + id + "'";
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
