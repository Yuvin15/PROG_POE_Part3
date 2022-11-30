using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data;
using System.Drawing;

namespace PROG_POE_Part3.Controllers
{
    public class ModuleAdd : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(string ModuleCode, string ModuleName, string ModuleCredits, string ClassHours, string WeeksAMT, string StartDate,
            string Username,  string Cal)
        {

            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            int creditNo = Convert.ToInt32(ModuleCredits);
            int weeks = Convert.ToInt32(WeeksAMT);
            int class_Hours = Convert.ToInt32(ClassHours);
            double finalStudy = 0;
            switch (Cal)
            {
                case "Add Module":
                    double finalStudy1 = (creditNo * 10) / weeks;
                    double finalStudy2 = finalStudy1 - class_Hours;
                    finalStudy = finalStudy2 * weeks;

                    string query = "Insert into Modules(Module_Code,Module_Name,Module_Credits,ClassHours,Self_Study_Total,Self_Study_Completed,Username) Values" +
                       "('" + ModuleCode + "','" + ModuleName + "','" + ModuleCredits + "','"
                            + ClassHours + "','" + finalStudy + "','" + 0 + "','Test')";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.ExecuteNonQuery();
                    break;

                case "Clear":
                    ModuleName = null;
                    ModuleCredits = null;
                    ClassHours = null;
                    WeeksAMT = null;
                    Username = null;
                    break;
            }
            ViewBag.Result = finalStudy;
            con.Close();

            return View();
        }
    }
}
