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

        [HttpPost]
        public ActionResult SelfyStudyLeft(string ModuleCode, string SelfStudyComplete, String Cal)
        {
            //All variables needed for the Controller
            User newUser = new User();
            double TotalStudyComplete = 0;
            double completeStudy1 = 0;
            double completeStudy2 = 0;

            //Creates all the SQL connections and establishes a connection with the database
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

           //Switch statement
            switch (Cal)
            {
                //If "Add Module" is clicked then it will run the following code
                case "Add Module":

                    SqlCommand query =new SqlCommand("SELECT Self_Study_Total FROM Modules WHERE Module_Code ='" + ModuleCode + "'");

                    //SQL queries
                    SqlDataAdapter da = new SqlDataAdapter(query);
                    da.SelectCommand.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //Converts the value into a double
                    TotalStudyComplete = Convert.ToDouble(query);;

                    //Converts the value into a double
                    completeStudy1 = Convert.ToDouble(SelfStudyComplete);
                    completeStudy2 = TotalStudyComplete - completeStudy1;

                    //string query2 = ("INSERT INTO Modules(Self_Study_Completed)VALUES (" + completeStudy2 + ") " +
                    //                 "WHERE Module_Code+'"+ ModuleCode + "'");

                    SqlCommand query2 = new SqlCommand("INSERT INTO Modules(Self_Study_Completed)VALUES (" + completeStudy1 + ") "
                                                        + "WHERE Module_Code+'" + ModuleCode + "'");

                    query2.ExecuteNonQuery();

                    break;
                    //If the ""Clear" button is clicked then it will clear all the textboxes
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
