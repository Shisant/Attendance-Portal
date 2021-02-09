using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Timetable
    {
        [Key]
        public int timeTableId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime time { get; set; }

        public string room { get; set; }

        public int classDuration { get; set; }

        

        List<Timetable> list = new List<Timetable>();
        public List<Timetable> List(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Timetable timetable = new Timetable();
                timetable.timeTableId = Convert.ToInt32(dataTable.Rows[i]["timeTableId"].ToString());
                timetable.time = Convert.ToDateTime(dataTable.Rows[i]["time"].ToString());
                timetable.room = dataTable.Rows[i]["room"].ToString();
                timetable.classDuration = Convert.ToInt32(dataTable.Rows[i]["classDuration"].ToString());
                list.Add(timetable);
            }
            return list;
        }
   
    }
}