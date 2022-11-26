using Microsoft.AspNetCore.Mvc;

namespace PROG_POE_Part3.Controllers
{
    public class LoginPage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
