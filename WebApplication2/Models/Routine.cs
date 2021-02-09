using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Routine
    {
        [Key]
        public int routineId { get; set; }
        
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual ClassDetails ClassFK { get; set; }

        
        public int timeTableId { get; set; }
        [ForeignKey("timeTableId")]
        public virtual Timetable timetableFK { get; set; }

        
        public int courseId { get; set; }
        [ForeignKey("courseId")]
        public virtual Course courseFK { get; set; }

        List<Routine> list = new List<Routine>();
        public List<Routine> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Routine routine = new Routine();
                routine.routineId = Convert.ToInt32(dataTable.Rows[i]["routineId"].ToString());
                routine.ClassId = Convert.ToInt32(dataTable.Rows[i]["ClassId"].ToString());
                routine.timeTableId = Convert.ToInt32(dataTable.Rows[i]["timetableId"].ToString());
                routine.courseId = Convert.ToInt32(dataTable.Rows[i]["courseId"].ToString());
                routine.courseName = dataTable.Rows[i]["courseName"].ToString();

                list.Add(routine);
            }
            return list;
        }


        [NotMapped]
        public string teachername { get; set; }

        [NotMapped]
        public string courseName { get; set; }

    }
}