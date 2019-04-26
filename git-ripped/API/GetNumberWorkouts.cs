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
    [Route("api/GetNumberWorkouts")]
    public class GetNumberWorkouts : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GET(int tok)
        {
            try
            {
                SqlConnection conn = Helper.OpenSqlConnection();
                int UserID;
                if ((UserID = Helper.CheckSessionToken(tok, conn)) != -1)
                {
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) AS Workouts FROM lift.Workout WHERE UserID = @UserID;", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    SqlDataReader reader = command.ExecuteReader();
                    int count = 0;
                    if (reader.HasRows)
                    {
                        reader.Read();
                        count = (int)reader["Workouts"];
                    }
                    count = (int)reader["Workouts"];                    
                    return StatusCode(200, "{\"NumberWorkouts\" : " + count + " }");
                }
                else
                {
                    string message = "{\"Error\":\"Session Token: " + tok + " Was Not Verified\"}";
                    return StatusCode(403, message);
                }
            }
            catch (Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }
    }
}
