using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TeacherStudent
    {
        [Key]
        public int teacherStudentId { get; set; } 

        public int teacherId { get; set; }

        [ForeignKey("teacherId")]
        public virtual Staff teacherIdFK{ get; set; }

        public int studentId { get; set; }
        [ForeignKey("studentId")]
        public virtual Student studentIdFK { get; set; }

        List<TeacherStudent> list = new List<TeacherStudent>();
        public List<TeacherStudent> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                TeacherStudent teacherStudent = new TeacherStudent();
                teacherStudent.teacherId = Convert.ToInt32(dataTable.Rows[i]["teacherId"].ToString());
                teacherStudent.studentId = Convert.ToInt32(dataTable.Rows[i]["StudentId"].ToString());
                teacherStudent.teachername=  dataTable.Rows[i]["teacherName"].ToString();
                teacherStudent.studentname = dataTable.Rows[i]["StudentName"].ToString();
                list.Add(teacherStudent);
            }
            return list;
        }

        [NotMapped]
        public string teachername { get; set; }

        [NotMapped]
        public string studentname { get; set; }

    }
}