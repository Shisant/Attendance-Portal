using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }

        public string Year { get; set; }

        public string Semester { get; set; } 

        List<Class> list = new List<Class>(); 
        public List<Class> List(DataTable dataTable)
        {

        }

    }
}