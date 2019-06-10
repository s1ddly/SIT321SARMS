using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{
    //public class Schedule
    //{

    //}

    public class ClassScheduleViewModel
    {
        public string unitCode { get; set; }
        public List<Lecture> classLecture { get; set; }
    }
}