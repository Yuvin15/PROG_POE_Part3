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

        SqlConnection con = new SqlConnection("Server=tcp:cldv10083835.database.windows.net,1433;Initial Catalog=PROGDB;Persist Security Info=False;User ID=ST10083835;Password=Keenless19;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public string AddEmployeeRecord(Module newModules)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Module_Code", newModules.ModuleCode);
                cmd.Parameters.AddWithValue("@Module_Name", newModules.ModuleName);
                cmd.Parameters.AddWithValue("@Module_Credits", newModules.ModuleCredits);
                cmd.Parameters.AddWithValue("@Self_Study_Total", newModules.SelfStudyTotal);
                cmd.Parameters.AddWithValue("@Self_Study_Completed", newModules.SelfStudyCompleted);
                cmd.Parameters.AddWithValue("@Username", newModules.Username);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message);
            }
        }
    }
}
