using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class StudentCourse
    {
        [Key]
        public int studentCourseId { get; set; }
        public int studentId { get; set; }

        [ForeignKey("studentId")]
        public virtual Student studentIdFK { get; set; }

        public int courseId { get; set; }

        [ForeignKey("courseId")]
        public virtual Course courseIdFK { get; set; }

        List<StudentCourse> list = new List<StudentCourse>();
        public List<StudentCourse> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                StudentCourse studentCourse = new StudentCourse();
                studentCourse.studentCourseId = Convert.ToInt32(dataTable.Rows[i]["studentCourseId"].ToString());
                studentCourse.studentId = Convert.ToInt32(dataTable.Rows[i]["StudentId"].ToString());
                studentCourse.courseId = Convert.ToInt32(dataTable.Rows[i]["courseId"].ToString());
                studentCourse.courseName = dataTable.Rows[i]["courseName"].ToString();
                studentCourse.studentName = dataTable.Rows[i]["studentName"].ToString();
                studentCourse.EnrollDate = Convert.ToDateTime(dataTable.Rows[i]["EnrollDate"].ToString());
                studentCourse.Email = dataTable.Rows[i]["Email"].ToString();
                studentCourse.Address = dataTable.Rows[i]["Address"].ToString();
                studentCourse.Contact = Convert.ToInt32(dataTable.Rows[i]["Contact"].ToString());
                list.Add(studentCourse);
            }
            return list;
        }

        [NotMapped]
        public string courseName { get; set; }

        [NotMapped]
        public string studentName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public DateTime EnrollDate { get; set; }

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public string Address { get; set; }

        [NotMapped]
        public int Contact { get; set; }

    }

}
