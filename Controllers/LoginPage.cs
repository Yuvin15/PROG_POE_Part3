using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data.SqlClient;

namespace PROG_POE_Part3.Controllers
{
    
    public class LoginPage : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();  
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void conString()
        {
            con.ConnectionString = "Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        [HttpPost]
        public ActionResult Verify(User newUser)
        {
            conString();
            con.Open();
            //con.Connection = con;
            cmd.CommandText = "SELECT Username,Password FROM Users WHERE Username ='"+newUser.Username
                            +"' and Password = '"+newUser.Password+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View();
            }



        }
    }
}
