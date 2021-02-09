using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Staff
    {
        [Key]
        public int teacherId { get; set; }
        [Required]
        public string teacherName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]

        [MaxLength(10)]
        public string Contact { get; set; }
        [Required]
        public string Email { get; set; }
        public String jobType { get; set; }

        List<Staff> list = new List<Staff>();
        public List<Staff> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Staff staff = new Staff();
                staff.teacherId = Convert.ToInt32(dataTable.Rows[i]["teacherId"].ToString());
                staff.teacherName = dataTable.Rows[i]["teacherName"].ToString();
                staff.Address = dataTable.Rows[i]["Address"].ToString();
                staff.Contact = dataTable.Rows[i]["Contact"].ToString();
                staff.Email = dataTable.Rows[i]["Email"].ToString();
                staff.jobType = dataTable.Rows[i]["JobType"].ToString();
                list.Add(staff);
            }
            return list;
        }

    }
}