using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gitripped.API
{
    [Route("api/CreateLift")]
public class CreateLift : Controller
{
        [HttpPost]
        public IActionResult Post([FromBody]JObject json)
        {
            try
            {
                CreateLiftItem lift = JsonConvert.DeserializeObject<CreateLiftItem>(json.ToString());

                SqlConnection conn = Helper.OpenSqlConnection();
                int UserID;
                if ((UserID = Helper.CheckSessionToken(lift.SessionToken, conn)) != -1)
                {
                    //Create the workout in the database with the max + 1 workoutid
                    SqlCommand command = new SqlCommand("INSERT INTO Lift.LiftList VALUES (COALESCE((SELECT MAX(WorkoutID) + 1 FROM Lift.Workout), 1), @LiftName);", conn);
                    command.Parameters.Add("@LiftName", System.Data.SqlDbType.VarChar);
                    command.Parameters["@LiftName"].Value = lift.LiftName;
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                else
                {
                    string error = Helper.ErrorCreator("Session Token: " + lift.SessionToken + " Was Not Verified");
                    return StatusCode(403, error);
                }
                return StatusCode(200);
            }
            catch (Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }
    }
}

public class CreateLiftItem
{
    public int SessionToken { get; set; }
    public string LiftName { get; set; }
}
