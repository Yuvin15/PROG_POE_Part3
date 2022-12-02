using Microsoft.AspNetCore.Mvc;
using PROG_POE_Part3.Models;

namespace PROG_POE_Part3.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User obj)

        {
            if (ModelState.IsValid)
            {
                ProgdbContext db = new ProgdbContext();
                db.Users.Add(obj);
                db.SaveChanges();
                //return RedirectToAction("Home/Index");

            }
            return View(obj);

        }
    }
}
