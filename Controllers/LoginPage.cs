using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PROG_POE_Part3.Models;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace PROG_POE_Part3.Controllers
{

    public class LoginPage : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string UsernameGet, string PasswordGet)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;

            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
                SqlCommand cmd = new SqlCommand("select Username, Password from Users where Username='" + UsernameGet.ToString()
                    + "'and Password='" + PasswordGet.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Closes connection
                    con.Close();
                }
                return View();
        }

    }
}


//[HttpPost]
//public ActionResult Authorize(PROG_POE_Part3.Models.User userModel, string Login_Username, string Login_Password)
//{
//    using (ProgdbContext db = new ProgdbContext())
//    {
//        var userDetails = db.Users.Where
//            (x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();

//        if (userDetails.Username == null)
//        {
//            userDetails.Username = Login_Username;  
//            return View("Index", userModel);
//        }
//        else
//        {
//            return RedirectToAction("Home", "Index");
//        }

//    }
//    return View();
//}


//public ActionResult LogIN()
//{
//    return View();
//}
//[HttpPost]
//public ActionResult LogIN(string Login_Username, string Login_Password, string Cal)
//{

//    switch (Cal)
//    {
//        case "Login":

//            SqlConnection con = new SqlConnection();

//            con.ConnectionString = @"Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
//            con.Open();

//            SqlCommand cmd = new SqlCommand("select Username, Password from Users where Username='" + Login_Username
//                + "'and Password='" + Login_Password + "'", con);
//            SqlDataAdapter da = new SqlDataAdapter(cmd);
//            DataTable dt = new DataTable();
//            da.Fill(dt);
//            if (dt.Rows.Count > 0)
//            {
//                newUser.Username = Login_Username;

//                newUser.Username = Login_Password;

//                con.Close();
//            }

//            ViewBag.Result = "Success!";
//            break;
//        case "Clear":
//            ViewBag.NewResult = Login_Username;

//            ViewBag.NewResult1 = Login_Password;
//            break;
//    }

//    return View();

//}
