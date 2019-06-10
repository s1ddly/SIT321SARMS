using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{

    public class Lecture : Class
    {
        
        public int LectureID { get; set; }

        public string Day { get; set; }

        public int StartTime { get; set; }

        public int Length { get; set; }

        public string Classroom { get; set; }

        public int UnitID { get; set; }

}