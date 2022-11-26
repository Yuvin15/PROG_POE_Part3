using Microsoft.AspNetCore.Mvc;

namespace PROG_POE_Part3.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Discount = "10$";
            return View();
        }
    }
}
