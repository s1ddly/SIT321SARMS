using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Models
{
    //public class ClassStudentAttendace
    //{
    //    public Student student { get; set; }
    //    //public Attendance studentAttendance { get; set; }
    //}

    public class ClassAttendaceViewModel
    {
        public List<Student> classStudent { get; set; }
        public List<AttendanceType> attendanceTypes { get; set; }
        public LectureClass Lectureclass { get; set; }
        public DateTime date { get; set; }
    }

    public class TimetableViewModel
    {
        public List<Lecturer> lecturers { get; set; }

    }
}