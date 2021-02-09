using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CourseTeacher
    {
        [Key]
        public int courseTeacherId { get; set; }

        public int courseId { get; set; }

        [ForeignKey("courseId")]
        public virtual Course courseIdFk { get; set; }

        public int teacherId { get; set; }

        [ForeignKey("teacherId")]
        public virtual Staff teacherIdFK { get; set; }

        List<CourseTeacher> list = new List<CourseTeacher>();
        public List<CourseTeacher> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                CourseTeacher courseTeacher = new CourseTeacher();
                courseTeacher.teacherId = Convert.ToInt32(dataTable.Rows[i]["teacherId"].ToString());
                courseTeacher.courseId = Convert.ToInt32(dataTable.Rows[i]["courseId"].ToString());
                courseTeacher.teacherName = dataTable.Rows[i]["teacherName"].ToString();
                courseTeacher.jobType = dataTable.Rows[i]["jobType"].ToString();
                courseTeacher.courseName = dataTable.Rows[i]["courseName"].ToString();
                list.Add(courseTeacher);

            }
            return list;
        }
        [NotMapped]
        public string teacherName { get; set; }

        [NotMapped]
        public string courseName { get; set; }

        [NotMapped]
        public string jobType { get; set; }

    }
}