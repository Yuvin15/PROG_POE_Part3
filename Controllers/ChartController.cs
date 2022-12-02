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
            //Creates all the SQL connections and establishes a connection with the database
            SqlConnection con =  new SqlConnection();
            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            con.Open();
            SqlCommand com;
            SqlDataReader dr;

            //Variables needed to allow the chart data to be displayed
            string Output = "";
            string Output2 = "";

            //Graphs x- and y-axis retrieved from the database 
            SqlCommand graphQuery1 =new SqlCommand("SELECT Module_Code FROM Modules",con);
            SqlCommand graphQuery2 = new SqlCommand("SELECT Self_Study_Total FROM Modules", con);

            //Converts the Queries into a string 
            SqlDataAdapter da = new SqlDataAdapter(graphQuery1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Output = dt.Rows[0][0].ToString();


            //Converts the Queries into a double
            SqlDataAdapter da2 = new SqlDataAdapter(graphQuery2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            Output2 = dt2.Rows[0][4].ToString();

            double Output3 = Convert.ToDouble(Output2);

            //Creates a list of all the graphs points needed to be displayed on the graph
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint(Output, Output3));
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            //Closes the conenction
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



