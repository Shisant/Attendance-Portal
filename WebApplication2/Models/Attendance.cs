using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Attendance
    {
        [Key]
        public int attendenceId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime AttendDate { get; set; }

        public string attendenceRemark { get; set; }


        public int timeTableId { get; set; }
        [ForeignKey("timeTableId")]
        public virtual Timetable TimetableIdFK { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student stu { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course courseCodeFK { get; set; }

        List<Attendance> list = new List<Attendance>();
        public List<Attendance> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Attendance attendance = new Attendance();
                attendance.attendenceId = Convert.ToInt32(dataTable.Rows[i]["attendenceId"].ToString());
                attendance.timeTableId = Convert.ToInt32(dataTable.Rows[i]["timetableId"].ToString());
                attendance.StudentId = Convert.ToInt32(dataTable.Rows[i]["StudentId"].ToString());
                attendance.CourseId = Convert.ToInt32(dataTable.Rows[i]["CourseId"].ToString());
                attendance.studentname = dataTable.Rows[i]["StudentName"].ToString();
                attendance.attendenceRemark = dataTable.Rows[i]["attendenceRemark"].ToString();
                attendance.AttendDate = Convert.ToDateTime(dataTable.Rows[i]["AttendDate"].ToString());
                attendance.courseName = dataTable.Rows[i]["CourseName"].ToString();
                attendance.time = Convert.ToDateTime(dataTable.Rows[i]["time"].ToString());
                list.Add(attendance);
            }
            return list;
        }

        [NotMapped]
        public string studentname { get; set; }

        [NotMapped]
        public string courseName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public DateTime time { get; set; }

    }


}