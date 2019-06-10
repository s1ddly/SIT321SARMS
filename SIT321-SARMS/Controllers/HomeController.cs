using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using SIT321_SARMS_Data;
using SIT321_SARMS.Models;

namespace SIT321_SARMS.Controllers
{
    public class HomeController : Controller
    {
        private SARMSDBEntities db = new SARMSDBEntities();
        public Boolean Auth(String UID)
        {
            String connstring = null;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dr;
            //String sql = "SELECT * FROM SESH";
            connstring = "Data Source=Sit321sarms.database.windows.net;Initial Catalog=SARMSDB;User ID=SIT321User;Password=SIT321sarms1";
            cnn = new SqlConnection(connstring);
            cnn.Open();
            var sql = @"EXEC	[dbo].[Auth]
		@UID = N'" + UID + "'";
            command = new SqlCommand(sql, cnn);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            //command.Parameters.Add(new SqlParameter("INID", UID));
            dr = command.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                var uout = dr.GetString(0);
                cnn.Close();
                //ViewBag.Message = uout;
                if (uout != "n")
                {
                    return true;
                }
                else
                {
                    cnn.Close();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public ActionResult Loginer()
        {
            var uname = Request["uname"];
            var pword = Request["pword"];
            //ViewBag.message = uname + pword;
            String connstring = null;
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dr;
            String sql = @"DECLARE @outy AS NCHAR(1) = ''
set @outy = (SELECT 
CASE
	WHEN (SELECT Role from Admin WHERE UID = '" + uname + @"' AND PWORD = '" + pword + @"') = 'a' 
		Then  'a'
	WHEN (SELECT Role from Student WHERE UID = '" + uname + @"' AND PWORD = '" + pword + @"') = 's'
		Then 's'
	WHEN (SELECT Role from Lecturer WHERE UID = '" + uname + @"' AND PWORD = '" + pword + @"') = 'l'
		Then 'l'
	Else ''
End)
IF @outy != '' AND '" + uname + @"' NOT IN (SELECT UID FROM SESH)
	INSERT INTO SESH VALUES('" + uname + @"', convert(time, SYSDATETIME()))
ELSE 
    UPDATE SESH SET TIMEST = convert(time, SYSDATETIME()) WHERE UID = '" + uname + @"'
SELECT @outy
";
            connstring = "Data Source=Sit321sarms.database.windows.net;Initial Catalog=SARMSDB;User ID=SIT321User;Password=SIT321sarms1";
            cnn = new SqlConnection(connstring);
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            dr = command.ExecuteReader();
            dr.Read();
            var uout = dr.GetString(0);
            cnn.Close();
            if (uout == "a" || uout == "s" || uout == "l"){
                HttpCookie cookcheck = new HttpCookie("u");
                HttpCookie cookid = new HttpCookie("cookid");
                cookid.Value = uname;
                cookcheck.Value = uout;
                Response.Cookies.Add(cookcheck);
                Response.Cookies.Add(cookid);
                Response.Flush();
                return View("~/Views/Home/Index.cshtml", Index());
            } else
            {
                ViewBag.message = "Error in login, please try again";
                return View("~/Views/Home/Login.cshtml", Login());
            } 
            //return View("~/Views/Home/" + uout, Index());
        }

        public ActionResult Logout()
        {
            ViewBag.Message = "Goodbye!";
            String UID = "";
            if (Request.Cookies["cookid"] != null)
            {
                UID = Request.Cookies["cookid"].Value.ToString();
                String connstring = null;
                SqlConnection cnn;
                SqlCommand command;
                SqlDataReader dr;
                String sql = @"DELETE FROM SESH WHERE UID = '" + UID + "'";
                connstring = "Data Source=Sit321sarms.database.windows.net;Initial Catalog=SARMSDB;User ID=SIT321User;Password=SIT321sarms1";
                cnn = new SqlConnection(connstring);
                cnn.Open();
                command = new SqlCommand(sql, cnn);
                dr = command.ExecuteReader();
                cnn.Close();
            }

            if (Request.Cookies["u"] != null)
            {
                var c = new HttpCookie("u");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            if (Request.Cookies["cookid"] != null)
            {
                var c = new HttpCookie("cookid");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            Response.Flush();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            String UID = "";
            if (Request.Cookies["cookid"] != null)
            {
                UID = Request.Cookies["cookid"].Value.ToString();
                if (Auth(UID))
                {
                    ViewBag.Authenticated = true;
                    return View();
                }
                else
                {
                    return View("~/Views/Home/Login.cshtml", Login());
                }
            }
            else
            {
                ViewBag.Authenticated = true;
                //return View();
                return View("~/Views/Home/Login.cshtml", Login());
            }
        }

        //    //if user not logged in then need redirect to login page

        //    return View();
        //}

        public ActionResult Timetable() {

            TimetableViewModel timetableData = new TimetableViewModel();
            List<Lecturer> lecturers = db.Lecturers.ToList();
            timetableData.lecturers = lecturers;

            ViewData.Model = timetableData;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            String UID = "";
            if (Request.Cookies["cookid"] != null)
            {
                UID = Request.Cookies["cookid"].Value.ToString();
                if (Auth(UID))
                {
                    return View();
                }
                else
                {
                    return View("~/Views/Home/Login.cshtml", Login());
                }
            }
            else
            {
                return View("~/Views/Home/Login.cshtml", Login());
            }
        }

        public ActionResult Contact()
        {
            String UID = "";
            if (Request.Cookies["cookid"] != null)
            {
                UID = Request.Cookies["cookid"].Value.ToString();
                if (Auth(UID))
                {
                    return View();
                } else
                {
                    return View("~/Views/Home/Login.cshtml", Login());
                }
            } else
            {
                return View("~/Views/Home/Login.cshtml", Login());
            }
        }
    }
}