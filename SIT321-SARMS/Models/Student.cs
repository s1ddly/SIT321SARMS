using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{

    public class Student : User
    {

        public DateTime EnrolmentDate { get; set; }

    }