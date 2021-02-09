using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Course
    {
        [Key]
        public int courseId { get; set; }

        [Required]
        public string courseName { get; set; }

        public int creditHour { get; set; }

        public string moduleLeader { get; set; }

        List<Course> list = new List<Course>();
        public List<Course> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Course course = new Course();
                course.courseId = Convert.ToInt32(dataTable.Rows[i]["courseId"].ToString());
                course.courseName = dataTable.Rows[i]["courseName"].ToString();
                course.creditHour = Convert.ToInt32(dataTable.Rows[i]["creditHour"].ToString());
                course.moduleLeader = dataTable.Rows[i]["moduleLeader"].ToString();
                list.Add(course);
            }
            return list;
        }

    }
}