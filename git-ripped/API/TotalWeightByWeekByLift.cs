using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gitripped.API
{
    [Route("api/TotalWeightByWeekByLift")]
    public class TotalWeightByWeekByLift : Controller
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
                    SqlCommand command = new SqlCommand("SELECT * FROM lift.TotalWeightByWeekAndLift WHERE UserID = @UserID;", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    SqlDataReader reader = command.ExecuteReader();
                    List<WeekObj> weekList = new List<WeekObj>();
                    while (reader.Read())
                    {
                        WeekObj temp = new WeekObj();
                        temp.TotalWeight = (int)reader["TotalWeight"];
                        DateTime tempWS = (DateTime)reader["WeekStart"];
                        DateTime tempWE = (DateTime)reader["WeekEnd"];
                        temp.WeekStart = tempWS.ToString("MM/dd/yyyy");
                        temp.WeekEnd = tempWE.ToString("MM/dd/yyyy");
                        temp.LiftName = reader["LiftName"].ToString();
                        weekList.Add(temp);
                    }

                    var message = JsonConvert.SerializeObject(weekList);
                    return StatusCode(200, message);
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

class WeekObj
    {
        public string WeekStart { get; set; }
        public string WeekEnd { get; set; }
        public string LiftName { get; set; }
        public int TotalWeight { get; set; }


        public WeekObj()
        {
            
        }
    }
}
