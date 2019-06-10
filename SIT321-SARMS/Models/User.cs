using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{

    public class User
    {
        
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime dob { get; set; }

        public List<Unit> currentUnits { get; set; }

    }