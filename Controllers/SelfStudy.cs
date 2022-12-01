using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;

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
            double completeStudy = 0;
            double completeStudy2 = 0;
            double completeStudy3 = 0;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

           
            switch (Cal)
            {
                case "Add Module":

                    string query =("SELECT Self_Study_Total FROM Modules WHERE Module_Code ='" + ModuleCode + "'");

                    string queryEnd = ("SELECT Self_Study_Completed FROM Modules WHERE Module_Code ='" + ModuleCode + "'");


                    //string query = "Insert into Modules(Module_Code,Module_Name,Module_Credits,ClassHours,Self_Study_Total,Self_Study_Completed,Username) Values" +
                    //   "('" + ModuleCode + "','" + ModuleName + "','" + ModuleCredits + "','"
                    //        + ClassHours + "','" + finalStudy + "','" + studyCompleted + "','Test')";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.ExecuteNonQuery();

                    TotalStudyComplete = Convert.ToDouble(queryEnd);

                    completeStudy = Convert.ToDouble(SelfStudyComplete);
                    completeStudy2 = TotalStudyComplete - completeStudy;
                    completeStudy3 = completeStudy + TotalStudyComplete;

                    string query2 = ("INSERT INTO Modules(Self_Study_Completed)VALUES (" + completeStudy3 + ") " +
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
