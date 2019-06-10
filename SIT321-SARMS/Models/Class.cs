using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{

    public class Class
    {
        public int ClassID { get; set; }

        public string ClassDayOfWeek { get; set; }

        public int ClassStartTime { get; set; }

        public int ClassEndTime { get; set; }

        public int ClassLocationID { get; set; }

        public int StaffID { get; set; }

        public int UnitID { get; set; }

        public static void getAlertRules()
        {
            // Method to get alert rules
        }

        public static void getStaffMember()
        {
            // Method to get staff member
        }

}