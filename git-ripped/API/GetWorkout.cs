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
        public IActionResult GET([FromBody]JObject json)
        {
            
            dynamic jsonResponse = json;
            int token = jsonResponse.Token;
            int workoutID = jsonResponse.WorkoutID;

            try
            {
                SqlConnection conn = OpenSqlConnection();
                int UserID;
                if ((UserID = CheckSessionToken(token, conn)) != -1)
                {
                    Workout workout = new Workout();
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

                        if(workout.NumberLifts != 0)
                        {
                            command = new SqlCommand("SELECT * FROM lift.LiftWithName WHERE WorkoutID = @WorkoutID ORDER BY LiftOrderNumber", conn);
                            command.Parameters.Add("@WorkoutID", System.Data.SqlDbType.Int);
                            command.Parameters["@WorkoutID"].Value = workoutID;
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Lift lift = new Lift((int)reader["LiftID"], (int)reader["WorkoutID"], (int)reader["NumberSets"], (int)reader["LiftOrderNumber"], (int)reader["LiftNameID"], (string)reader["LiftName"]);
                                if(lift.Sets != 0)
                                {
                                    SqlCommand command2 = new SqlCommand("SELECT * FROM lift.LiftSet WHERE LiftID = @LiftID", conn);
                                    command2.Parameters.Add("@LiftID", System.Data.SqlDbType.Int);
                                    command2.Parameters["@LiftID"].Value = lift.LiftID;
                                    SqlDataReader reader2 = command2.ExecuteReader();
                                    while (reader2.Read())
                                    {
                                        Set set = new Set((int)reader2["SetID"], (int)reader2["LiftID"], (int)reader2["Repetitions"], (int)reader2["Weight"], (int)reader2["SetOrderNumber"]);
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
                        string error = ErrorCreator("Workout was not found in the database");
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
            catch(Exception e)
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

        static int CheckSessionToken(int token, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand("Select Active, UserID From usr.SessionToken WHERE SessionToken = @Token", conn);
            command.Parameters.Add("@Token", System.Data.SqlDbType.Int);
            command.Parameters["@Token"].Value = token;
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();
                bool Active = (bool)reader["Active"];
                int UserID = (int)reader["UserID"];
                if (!Active)
                {
                    reader.Close();
                    return -1;
                }
                else
                {
                    reader.Close();
                    return UserID;
                }
            }
            else
            {
                reader.Close();
                return -1;
            }

        }

        static string ErrorCreator(string error)
        {
            string message = "{\"Error\":\"" + error + "\"}";
            return message;
        }
    }
}



class Workout
{
    public int WorkoutID { get; set; }
    public int UserID { get; set; }
    public int NumberLifts { get; set; }
    public string WorkoutComplete { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime CompleteDateTime { get; set; }
    public List<Lift> Lifts { get; set; }

    public Workout()
    {
        Lifts = new List<Lift>();
    }
}

class Lift
{
    public int LiftID { get; set; }
    public int WorkoutID { get; set; }
    public int Sets { get; set; }
    public int LiftOrderNumber { get; set; }
    public int LiftNameID { get; set; }
    public string LiftName { get; set; }
    public List<Set> SetList { get; set; }

    public Lift()
    {
        SetList = new List<Set>();
    }

    public Lift(int liftID, int workoutID, int sets, int liftOrderNumber, int liftNameID, string liftName)
    {
        LiftID = liftID;
        WorkoutID = workoutID;
        Sets = sets;
        LiftOrderNumber = liftOrderNumber;
        LiftNameID = liftNameID;
        LiftName = liftName;
        SetList = new List<Set>();
    }
}

class Set
{
    public int SetID { get; set; }
    public int LiftID { get; set; }
    public int Repetitions { get; set; }
    public int Weight { get; set; }
    public int SetOrderNumber { get; set; }

    public Set()
    {

    }

    public Set(int setID, int liftID, int repetitions, int weight, int setOrderNumber)
    {
        SetID = setID;
        LiftID = liftID;
        Repetitions = repetitions;
        Weight = weight;
        SetOrderNumber = setOrderNumber;
    }
}


