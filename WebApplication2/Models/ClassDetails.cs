using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ClassDetails
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }

        public string Year { get; set; }

        public string Semester { get; set; }

        List<ClassDetails> list = new List<ClassDetails>();
        public List<ClassDetails> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ClassDetails classDetails = new ClassDetails();
                classDetails.ClassId = Convert.ToInt32(dataTable.Rows[i]["ClassId"].ToString());
                classDetails.ClassName = dataTable.Rows[i]["ClassName"].ToString();
                classDetails.Year = dataTable.Rows[i]["Year"].ToString();
                classDetails.Semester = dataTable.Rows[i]["Semester"].ToString();
                list.Add(classDetails);
            }
            return list;
        }

    }
}