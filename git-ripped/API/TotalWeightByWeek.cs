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
    [Route("api/TotalWeightByWeek")]
    public class TotalWeightByWeek : Controller
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
                    SqlCommand command = new SqlCommand("SELECT * FROM lift.TotalWeightByWeek WHERE UserID = @UserID;", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    SqlDataReader reader = command.ExecuteReader();
                    List<WeightByWeekObj> wbwList = new List<WeightByWeekObj>();
                    while (reader.Read())
                    {
                        WeightByWeekObj wbw = new WeightByWeekObj();
                        wbw.UserID = (int)reader["UserID"];
                        wbw.TotalWeight = (int)reader["TotalWeight"];
                        DateTime tempWS = (DateTime)reader["WeekStart"];
                        DateTime tempWE = (DateTime)reader["WeekEnd"];
                        wbw.WeekStart = tempWS.ToString("MM/dd/yyyy");
                        wbw.WeekEnd = tempWE.ToString("MM/dd/yyyy");
                        wbwList.Add(wbw);
                    }

                    var message = JsonConvert.SerializeObject(wbwList);
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

        class WeightByWeekObj
        {
            public int UserID { get; set; }
            public int TotalWeight { get; set; }
            public string WeekStart { get; set; }
            public string WeekEnd { get; set; }
        }
}
