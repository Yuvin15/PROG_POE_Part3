using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace PROG_POE_Part3.Controllers
{
    
    public class LoginPage : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(PROG_POE_Part3.Models.User userModel)
        {
            using (ProgdbContext db = new ProgdbContext())
            {
                var userDetails = db.Users.Where
                    (x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();

                if(userDetails == null)
                {
                    //userDetails.loginError = "Wrong username/password";
                    return View("Index", userModel);
                }
                else
                {
                    return RedirectToAction("Home","Index");
                }

            }
                return View();
        }
    }
}
