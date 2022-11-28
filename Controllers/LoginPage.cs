using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data.SqlClient;

namespace PROG_POE_Part3.Controllers
{
    
    public class LoginPage : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize()
        {
            return View();
        }
    }
}
