using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PROG_POE_Part3.Models;
using System.Data;

namespace PROG_POE_Part3.Controllers
{
    public class ChartController : Controller
    {

            public ActionResult Index()
            {

            SqlConnection con =  new SqlConnection();
            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            SqlCommand com;
            SqlDataReader dr;

            string Output = "";
            string Output2 = "";

            SqlCommand graphQuery1 =new SqlCommand("SELECT Module_Code FROM Modules",con);
            SqlCommand graphQuery2 = new SqlCommand("SELECT Self_Study_Total FROM Modules", con);

            SqlDataAdapter da = new SqlDataAdapter(graphQuery1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Output = dt.Rows[0][0].ToString();
            Output2 = dt.Rows[0][4].ToString();

            double Output3 = Convert.ToDouble(Output2);

            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint(Output, Output3));
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            con.Close();
            return View();
        }
    }
}

//public ActionResult Index()
//{
//    List<DataPoint> dataPoints = new List<DataPoint>();

//    dataPoints.Add(new DataPoint("Economics", 1));
//    dataPoints.Add(new DataPoint("Physics", 2));
//    dataPoints.Add(new DataPoint("Literature", 4));
//    dataPoints.Add(new DataPoint("Chemistry", 4));
//    dataPoints.Add(new DataPoint("Literature", 9));
//    dataPoints.Add(new DataPoint("Physiology or Medicine", 11));
//    dataPoints.Add(new DataPoint("Peace", 13));

//    ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

//    return View();
//}



