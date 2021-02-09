using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public string GroupName { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student studentCode { get; set; }

        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual Faculty facultyCodeFK { get; set; }

        List<Groups> list = new List<Groups>();
        public List<Groups> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Groups groups = new Groups();
                groups.GroupId = Convert.ToInt32(dataTable.Rows[i]["GroupId"].ToString());
                groups.GroupName = dataTable.Rows[i]["GroupName"].ToString();
                groups.FacultyId = Convert.ToInt32(dataTable.Rows[i]["FacultyId"].ToString());
                groups.facultyName = dataTable.Rows[i]["Name"].ToString();
                groups.StudentId = Convert.ToInt32(dataTable.Rows[i]["studentId"].ToString());
                groups.EnrollDate = Convert.ToDateTime(dataTable.Rows[i]["EnrollDate"].ToString());
                groups.studentName = dataTable.Rows[i]["studentName"].ToString();

                list.Add(groups);

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