using Microsoft.AspNetCore.Mvc;
using PROG_POE_Part3.Models;

namespace PROG_POE_Part3.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var entities = new ProgdbContext();

            return View(entities.Modules.ToList());
            return View();
        }
    }
}
