using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report

        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult IndividualStudentMonthly(string id)
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            string sql = "Select s.studentName, c.courseName, a.CourseID, a.attendenceRemark, a.AttendDate from Attendances a JOIN Students s ON a.studentID = s.studentID JOIN Courses c ON c.CourseID = a.CourseID Where s.studentID='" + id + "' and a.AttendDate Between '" + startDate + "' and '" + endDate + "'";
            DataTable dt = db.List(sql);
            if (dt.Rows.Count > 0)
            {
                var list = new Attendance().List(dt);
                return View(list);
            }
            else
            {
                var list = new List<Attendance>();
                return View(list);

            }

        }
        [HttpPost]
        public ActionResult IndividualStudentMonthly(string id, FormCollection fm)
        {
            DateTime now = Convert.ToDateTime(fm["DatePicker11"]);
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            string sql = "Select s.studentName, c.courseName, a.CourseID, a.attendenceRemark, a.AttendDate from Attendances a JOIN Students s ON a.studentID = s.studentID JOIN Courses c ON c.CourseID = a.CourseID Where s.studentID='" + id + "' and a.AttendDate Between '" + startDate + "' and '" + endDate + "'";
            DataTable dt = db.List(sql);
            if (dt.Rows.Count > 0)
            {
                var list = new Attendance().List(dt);
                return View(list);
            }
            else
            {
                var list = new List<Attendance>();
                return View(list);

            }

        }

    }
}