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
    [Route("api/Workout")]
    public class GetWorkout : Controller
    {
        // GET api/Workout
        [HttpGet]
        public IActionResult GET(int tok, int workID)
        {

            int token = tok;
            int workoutID = workID;

            try
            {
                SqlConnection conn = Helper.OpenSqlConnection();
                int UserID;
                if ((UserID = Helper.CheckSessionToken(token, conn)) != -1)
                {
                    GWorkout workout = new GWorkout();
                    workout.WorkoutID = workoutID;
                    workout.UserID = UserID;

                    SqlCommand command = new SqlCommand("SELECT NumberLifts, WorkoutComplete, StartDateTime, CompleteDateTime FROM lift.Workout WHERE WorkoutID = @WorkoutID", conn);
                    command.Parameters.Add("@WorkoutID", System.Data.SqlDbType.Int);
                    command.Parameters["@WorkoutID"].Value = workoutID;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        workout.NumberLifts = (int)reader["NumberLifts"];
                        workout.WorkoutComplete = (string)reader["WorkoutComplete"];
                        if (!DBNull.Value.Equals(reader["StartDateTime"]))
                        {
                            workout.StartDateTime = (DateTime)reader["StartDateTime"];
                        }
                        if (!DBNull.Value.Equals(reader["CompleteDateTime"]))
                        {
                            workout.CompleteDateTime = (DateTime)reader["CompleteDateTime"];
                        }
                        reader.Close();

                        if (workout.NumberLifts != 0)
                        {
                            command = new SqlCommand("SELECT * FROM lift.LiftWithName WHERE WorkoutID = @WorkoutID ORDER BY LiftOrderNumber", conn);
                            command.Parameters.Add("@WorkoutID", System.Data.SqlDbType.Int);
                            command.Parameters["@WorkoutID"].Value = workoutID;
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                GLift lift = new GLift((int)reader["LiftID"], (int)reader["WorkoutID"], (int)reader["NumberSets"], (int)reader["LiftOrderNumber"], (int)reader["LiftNameID"], (string)reader["LiftName"]);
                                if (lift.Sets != 0)
                                {
                                    SqlCommand command2 = new SqlCommand("SELECT * FROM lift.LiftSet WHERE LiftID = @LiftID", conn);
                                    command2.Parameters.Add("@LiftID", System.Data.SqlDbType.Int);
                                    command2.Parameters["@LiftID"].Value = lift.LiftID;
                                    SqlDataReader reader2 = command2.ExecuteReader();
                                    while (reader2.Read())
                                    {
                                        GSet set = new GSet((int)reader2["SetID"], (int)reader2["LiftID"], (int)reader2["Repetitions"], (int)reader2["Weight"], (int)reader2["SetOrderNumber"]);
                                        lift.SetList.Add(set);
                                    }
                                }
                                workout.Lifts.Add(lift);
                            }
                            var message = JsonConvert.SerializeObject(workout);
                            return StatusCode(200, message);
                        }
                        else
                        {
                            var message = JsonConvert.SerializeObject(workout);
                            return StatusCode(200, message);
                        }
                    }
                    else
                    {
                        string error = Helper.ErrorCreator("Workout was not found in the database");
                        reader.Close();
                        return StatusCode(404, error);
                    }
                }
                else
                {
                    string message = "{\"Error\":\"Session Token: " + token + " Was Not Verified\"}";
                    return StatusCode(403, message);
                }
            }
            catch (Exception e)
            {
                string message = "{\"Error\":\"" + e.ToString() + "\"}";
                return StatusCode(400, message);
            }
        }

        



        
    }
}



