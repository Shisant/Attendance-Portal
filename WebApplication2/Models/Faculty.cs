using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        public string Name { get; set; }

        List<Faculty> list = new List<Faculty>();
        public List<Faculty> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Faculty faculty = new Faculty();
                faculty.FacultyId = Convert.ToInt32(dataTable.Rows[i]["FacultyId"].ToString());
                faculty.Name = dataTable.Rows[i]["Name"].ToString();
                
                list.Add(faculty);
            }
            return list;
        }

    }
}