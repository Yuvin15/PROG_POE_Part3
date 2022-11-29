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

    }
}
