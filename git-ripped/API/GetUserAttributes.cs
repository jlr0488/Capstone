using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gitripped.API
{
    [Route("api/GetAttributes")]
    public class GetUserAttributes : Controller
    {
        // GET api/Workout
        [HttpGet]
        //public IActionResult GET([FromBody]JObject json)
        public IActionResult GET(int tok)
        {
            int UserID;
            try
            {
                SqlConnection conn = OpenSqlConnection();                
                if((UserID = Helper.CheckSessionToken(tok, conn)) != -1)
                {

                }

                //int UserID;
                //UserID = CheckLogin(token, conn);



                if ((UserID = Helper.CheckSessionToken(tok, conn))!= -1)
                {
                    Attributes attributes = new Attributes();

                    SqlCommand command = new SqlCommand("SELECT Height, StartingWeight, CurrentWeight, GoalWeight, Gender, Birthday, WaistMeasure, ArmMeasure, ChestMeasure, BackMeasure, LegMeasure FROM usr.Attributes WHERE UserID = @UserID", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        attributes.Height = (decimal)reader["Height"];
                        attributes.StartingWeight = (decimal)reader["StartingWeight"];
                        attributes.CurrentWeight = (decimal)reader["CurrentWeight"];
                        attributes.GoalWeight = (decimal)reader["GoalWeight"];
                        attributes.Gender = (string)reader["Gender"];
                        attributes.Birthday = (DateTime)reader["Birthday"];
                        attributes.WaistMeasure = (decimal)reader["WaistMeasure"];
                        attributes.ArmMeasure = (decimal)reader["ArmMeasure"];
                        attributes.ChestMeasure = (decimal)reader["ChestMeasure"];
                        attributes.BackMeasure = (decimal)reader["BackMeasure"];
                        attributes.LegMeasure = (decimal)reader["LegMeasure"];
                        reader.Close();

                        var message = JsonConvert.SerializeObject(attributes);
                        return StatusCode(200, message);

                    }
                    else
                    {
                        string error = ErrorCreator("User was not found in the database");
                        reader.Close();
                        return StatusCode(404, error);
                    }
                }
                else
                {
                    string message = "{\"Error\":\"Invalid Token\"}";
                    return StatusCode(403, message);
                }
            }
            catch (Exception e)
            {
                string message = "{\"Error\":\"" + e.ToString() + "\"}";
                return StatusCode(400, message);
            }
        }



        static SqlConnection OpenSqlConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=tcp:gitripped.database.windows.net,1433;Initial Catalog=gitripped;Persist Security Info=False;User ID=joshrobbins;Password=TempPass1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=True";
            conn.Open();
            return conn;
        }

        //public int CheckLogin(int token1, SqlConnection conn)
        //{
        //    SqlCommand command = new SqlCommand("Select UserID From usr.SessionToken WHERE (SessionToken = @SessionToken) AND (Active = 1)", conn);
        //    command.Parameters.Add("@SessionToken", System.Data.SqlDbType.Int);
        //    command.Parameters["@SessionToken"].Value = token1;
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        reader.Read();
        //        int ID = (int)reader["UserID"];
        //        reader.Close();

        //        return ID;
        //    }
        //    else
        //    {
        //        reader.Close();
        //        return -1;
        //    }

        //}

        static string ErrorCreator(string error)
        {
            string message = "{\"Error\":\"" + error + "\"}";
            return message;
        }
    }
}

class Attributes
{
    //public int SessionToken { get; set; }
    public decimal Height { get; set; }
    public decimal StartingWeight { get; set; }
    public decimal CurrentWeight { get; set; }
    public decimal GoalWeight { get; set; }
    public string Gender { get; set; }
    //sql date is in this format: YYY-MM-DD, but can recieve date in the DD-MM-YYYY format as well
    public DateTime Birthday { get; set; }
    public decimal WaistMeasure { get; set; }
    public decimal ArmMeasure { get; set; }
    public decimal ChestMeasure { get; set; }
    public decimal BackMeasure { get; set; }
    public decimal LegMeasure { get; set; }

}

