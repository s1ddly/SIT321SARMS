using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{

    public class Lecturer : User
    {
        
        public int DeptID { get; set; }

        public int OfficeID { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

    }