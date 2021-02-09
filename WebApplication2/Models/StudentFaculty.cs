using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class StudentFaculty
    {
        [Key]
        public int studentFacultyId { get; set; }
        public int facultyId { get; set; }
        [ForeignKey("facultyId")]
        public virtual Faculty facultyIdFK { get; set; }
        public int studentId { get; set; }
        [ForeignKey("studentId")]
        public virtual Student studentIdFK { get; set; }

        List<StudentFaculty> list = new List<StudentFaculty>();
        public List<StudentFaculty> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                StudentFaculty studentFaculty = new StudentFaculty();
                studentFaculty.studentFacultyId = Convert.ToInt32(dataTable.Rows[i]["studentFacultyId"].ToString());
                studentFaculty.facultyId = Convert.ToInt32(dataTable.Rows[i]["facultyId"].ToString());
                studentFaculty.studentId = Convert.ToInt32(dataTable.Rows[i]["studentId"].ToString());
                studentFaculty.studentName = dataTable.Rows[i]["studentName"].ToString();
                studentFaculty.facultyName = dataTable.Rows[i]["Name"].ToString();
                studentFaculty.EnrollDate = Convert.ToDateTime(dataTable.Rows[i]["EnrollDate"].ToString());
                list.Add(studentFaculty);

            }
            return list;
        }
        [NotMapped]
        public string facultyName { get; set; }

        [NotMapped]
        public string studentName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [NotMapped]
        public DateTime EnrollDate { get; set; }
    }
}

   
        
                
      
           


    