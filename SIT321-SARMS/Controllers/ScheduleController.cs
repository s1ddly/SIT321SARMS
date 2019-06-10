using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIT321_SARMS.Models;
using SIT321_SARMS_Data;

namespace SIT321_SARMS.Controllers
{
    public class ScheduleController : Controller
    {
        private SARMSDBEntities db = new SARMSDBEntities();

        // GET: Schedule
        public ActionResult Index(string unitCode)
        {
            unitCode = "SIT321";

            ClassScheduleViewModel classScheduleViewModel = new ClassScheduleViewModel();

            List<Lecture> classLecture = db.Lectures.Where(e => e.UnitCode == unitCode).ToList();
            classScheduleViewModel.classLecture = classLecture;
            classScheduleViewModel.unitCode = unitCode;

            ViewData.Model = classScheduleViewModel;
            return View();
        }

        public bool AddLecture(string unit, int day, TimeSpan start, double length, string classroom)
        {
            Lecture addLecture = new Lecture()
            {
                UnitCode = unit,
                Day = day,
                StartTime = new DateTime().Add(start),
                Length = length,
                Classroom = classroom
            };

            db.Lectures.Add(addLecture);
            db.SaveChanges();

            return true;
        }

        public bool RemoveLecture(int lecture)
        {

            Lecture removeLecture = new Lecture()
            {
                LectureId = lecture
            };

            db.Lectures.Attach(removeLecture);
            db.Lectures.Remove(removeLecture); //Entry(removeLecture).State = System.Data.Entity.EntityState.Deleted;   
            db.SaveChanges();

            return true;
        }
    }
}