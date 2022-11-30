using Microsoft.AspNetCore.Mvc;

namespace PROG_POE_Part3.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
