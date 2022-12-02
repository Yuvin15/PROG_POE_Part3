using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data;

namespace PROG_POE_Part3.Controllers
{
    public class SelfStudy : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult SelfyStudyLeft()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelfyStudyLeft(string ModuleCode, string SelfStudyComplete, String Cal)
        {

            User newUser = new User();
            double TotalStudyComplete = 0;
            double completeStudy1 = 0;
            double completeStudy2 = 0;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

           
            switch (Cal)
            {
                case "Add Module":

                    SqlCommand query =new SqlCommand("SELECT Self_Study_Total FROM Modules WHERE Module_Code ='" + ModuleCode + "'");

                    SqlDataAdapter da = new SqlDataAdapter(query);
                    da.SelectCommand.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    TotalStudyComplete = Convert.ToDouble(query);;

                    completeStudy1 = Convert.ToDouble(SelfStudyComplete);
                    completeStudy2 = TotalStudyComplete - completeStudy1;

                    string query2 = ("INSERT INTO Modules(Self_Study_Completed)VALUES (" + completeStudy2 + ") " +
                                     "WHERE Module_Code+'"+ ModuleCode + "'");

                    break;

                case "Clear":
                    ModuleCode = null;
                    SelfStudyComplete = null;
                    //Username = null;
                    break;
            }

            ViewBag.Result = completeStudy2;
            con.Close();

            return View();
        }
    }
}
