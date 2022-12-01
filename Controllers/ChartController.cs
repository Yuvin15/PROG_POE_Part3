using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PROG_POE_Part3.Models;

namespace PROG_POE_Part3.Controllers
{
    public class ChartController : Controller
    {
            public ActionResult Index()
            {
                List<DataPoint> dataPoints = new List<DataPoint>();

                dataPoints.Add(new DataPoint("Economics", 1));
                dataPoints.Add(new DataPoint("Physics", 2));
                dataPoints.Add(new DataPoint("Literature", 4));
                dataPoints.Add(new DataPoint("Chemistry", 4));
                dataPoints.Add(new DataPoint("Literature", 9));
                dataPoints.Add(new DataPoint("Physiology or Medicine", 11));
                dataPoints.Add(new DataPoint("Peace", 13));

                ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

                return View();
            }
    }
}
    


