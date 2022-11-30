using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data;

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
        public ActionResult Calculate(string ModuleName, string ModuleCredits, string ClassHours, string WeeksAMT, string StartDate
            ,string Username,  string Cal)
        {
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
            return View();
        }
    }
}
