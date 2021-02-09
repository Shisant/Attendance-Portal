using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Role
        public ActionResult Index()
        {
            string sql = "Select * from AspNetUsers u JOIN AspNetUserRoles ur ON ur.UserId = u.Id JOIN AspNetRoles r ON r.Id =ur.RoleID";
            DataTable dt = db.List(sql);

            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, string> aa = new Dictionary<string, string>();
                aa.Add("Email", dt.Rows[i]["UserName"].ToString());
                aa.Add("Name", dt.Rows[i]["Name"].ToString());
                list.Add(aa);
            }

            ViewBag.list = list;
            return View();
        }
        public ActionResult Create() {

            string sql = "Select * from AspNetRoles";
            DataTable dt = db.List(sql);
            List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, string> aa = new Dictionary<string, string>();
                aa.Add("Email", dt.Rows[i]["RoleId"].ToString());
                aa.Add("Name", dt.Rows[i]["Name"].ToString());
                list.Add(aa);
            }

            ViewBag.drop = new SelectList(list, "RoleId", "Name");

            ViewBag.list = list;
            return View();
        }
        public ActionResult AssignRole()
        {


            ViewBag.roles = new SelectList(db.Roles.ToList(), "Name", "Name");


            return View();

        }
        
       
    }
}