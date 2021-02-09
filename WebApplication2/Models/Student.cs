using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollDate { get; set; }


        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [MaxLength(10)]
        [Required]
        public string Contact { get; set; }


        List<Student> list = new List<Student>();
        public List<Student> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Student student = new Student();
                student.StudentId = Convert.ToInt32(dataTable.Rows[i]["StudentId"].ToString());
                student.EnrollDate = Convert.ToDateTime(dataTable.Rows[i]["EnrollDate"].ToString());
                student.StudentName = dataTable.Rows[i]["StudentName"].ToString();
                student.Email = dataTable.Rows[i]["Email"].ToString();
                student.Address = dataTable.Rows[i]["Address"].ToString();
                student.Contact = dataTable.Rows[i]["Contact"].ToString();

                list.Add(student);
            }
            return list;
        }

    }
}