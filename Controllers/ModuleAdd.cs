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
            /*string Username,*/ string StudyDone , string Cal)
        {
            //Creates all the SQL connections and establishes a connection with the database
            User newUser = new User();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();

            //Gets all the data from the View
            double creditNo = Convert.ToDouble(ModuleCredits);
            double weeks = Convert.ToDouble(WeeksAMT);
            double class_Hours = Convert.ToDouble(ClassHours);
            double studyCompleted = Convert.ToDouble(StudyDone);
            double finalStudy = 0;
            switch (Cal)
            {
                //Switch statments to check which button is clicked
                //If "Add module" is clicked then it will store the values in the database after doing all of these calculations
                case "Add Module":
                    double finalStudy1 = (creditNo * 10) / weeks;
                    double finalStudy2 = finalStudy1 - class_Hours;
                    finalStudy = finalStudy2 * weeks;

                    string query = "Insert into Modules(Module_Code,Module_Name,Module_Credits,ClassHours,Self_Study_Total,Self_Study_Completed, Username) Values" +
                       "('" + ModuleCode + "','" + ModuleName + "','" + ModuleCredits + "','"
                            + ClassHours + "','" + finalStudy + "','" + 0 + "'" +newUser.Username+ "')";
                    //SQL command to input into a database
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.ExecuteNonQuery();
                    break;

                    //If the "Clear" button is clicked then it will clear all the following text boxes
                case "Clear":
                    ModuleName = null;
                    ModuleCredits = null;
                    ClassHours = null;
                    WeeksAMT = null;
                    //Username = null;
                    break;
            }
            // The result tab will display the calculation after the user inputs everything
            ViewBag.Result = finalStudy;
            //Closes the connection
            con.Close();

            return View();
        }
    }
}
