using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using SIT321_SARMS.Models;
using SIT321_SARMS_Data;
using SIT321_SARMS;

namespace SIT321_SARMS.Controllers
{
    public class AttendanceController : Controller
    {
        private SARMSDBEntities db = new SARMSDBEntities();

        public ActionResult Index(int? lectureClass, DateTime? date)
        {
            lectureClass = 1; //TODO: need to take in parameter
            DateTime selectedDate = DateTime.Now.Date;

            //Define class view model
            ClassAttendaceViewModel classAttendaceViewModel = new ClassAttendaceViewModel();
            classAttendaceViewModel.Lectureclass = db.LectureClasses.Where(e => e.ClassID == lectureClass).FirstOrDefault();

            //Select stdents in class
            List<Student> classStudents = db.Students.Where(e => e.Lec1 == "SIT321" || e.Lec2 == "SIT321" || e.Lec3 == "SIT321" || e.Lec4 == "SIT321" || e.Lec5 == "SIT321" || e.Lec6 == "SIT321").ToList();

            //return list of students in lecture
            List<AttendanceType> AttendanceTypes = db.AttendanceTypes.Where(e => e.AttendanceTypeActive == true).OrderBy(e => e.AttendanceTypeName).ToList();
            classAttendaceViewModel.attendanceTypes = AttendanceTypes;

            classAttendaceViewModel.classStudent = classStudents;
            classAttendaceViewModel.date = selectedDate;

            ViewData.Model = classAttendaceViewModel;
            return View();
        }

        public int AddAttendance(int studentID, int lectureClass, int type, string date)
        {
            Student selectedStudent = db.Students.Where(e => e.ID == studentID).FirstOrDefault();
            DateTime classDate = DateTime.Parse(date);

            //check if has valid student
            if (selectedStudent != null)
            {
                //create attendance object
                Attendance AttendanceRecord = new Attendance()
                {
                    Active = true,
                    Type = type,
                    ClassID = lectureClass,
                    Date = classDate,
                    EntryDate = DateTime.Now,
                    StudentID = studentID
                    //need to get the current user id

                };

                db.Attendances.Add(AttendanceRecord);
                db.SaveChanges();
            }

            return 1;
        }

        public void RemoveStudentAttendance(int studentID, int lectureClass, string date) {

            DateTime classDate = DateTime.Parse(date);

            List<Attendance> StudentClassAttendance = db.Attendances.Where(e => e.ClassID == lectureClass && e.StudentID == studentID && e.Date == classDate).ToList();

            if (StudentClassAttendance.Any())
            {
                foreach (Attendance record in StudentClassAttendance)
                {
                    db.Attendances.Remove(db.Attendances.Where(e => e.AttendanceID == record.AttendanceID).FirstOrDefault());
                    db.SaveChanges();
                }
            }
        }
    }
}