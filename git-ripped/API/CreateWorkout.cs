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
    [Route("api/CreateWorkout")]
public class CreateWorkout : Controller
{


    // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]JObject json)
        {
            try
            {
                Workout workout = JsonConvert.DeserializeObject<Workout>(json.ToString());
                SqlConnection conn = OpenSqlConnection();
                int UserID;
                if ((UserID = CheckSessionToken(workout.SessionToken, conn)) != -1)
                {
                    //Create the workout in the database with the max + 1 workoutid
                    SqlCommand command = new SqlCommand("INSERT INTO Lift.Workout VALUES (COALESCE((SELECT MAX(WorkoutID) + 1 FROM Lift.Workout), 1), @UserID, @NumberLifts, @WorkoutComplete, @StartDatetime, @CompleteDatetime, DATEPART(yyyy, @CompleteDatetime), DATEPART(wk, @CompleteDatetime));", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    command.Parameters.Add("@NumberLifts", System.Data.SqlDbType.Int);
                    command.Parameters["@NumberLifts"].Value = workout.NumberLifts;
                    command.Parameters.Add("@WorkoutComplete", System.Data.SqlDbType.Char);
                    command.Parameters["@WorkoutComplete"].Value = workout.WorkoutComplete;
                    command.Parameters.Add("@StartDatetime", System.Data.SqlDbType.DateTime);
                    command.Parameters["@StartDatetime"].Value = workout.StartDateTime;
                    command.Parameters.Add("@CompleteDatetime", System.Data.SqlDbType.DateTime);
                    command.Parameters["@CompleteDatetime"].Value = workout.CompleteDateTime;
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();

                    //Get the new workoutid from the database
                    command = new SqlCommand("SELECT MAX(WorkoutID) AS WorkoutID FROM Lift.Workout WHERE UserID = @UserID", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    reader = command.ExecuteReader();
                    reader.Read();
                    int WorkoutID = (int)reader["WorkoutID"];
                    reader.Close();


                    foreach (var lift in workout.Lifts)
                    {
                        //Create a new lift with max + 1 liftID
                        command = new SqlCommand("INSERT INTO Lift.Lift VALUES (COALESCE((SELECT MAX(LiftID) + 1 FROM Lift.Lift), 1), @WorkoutID, @NumberSets, @LiftOrderNumber, @LiftNameID);", conn);
                        command.Parameters.Add("@WorkoutID", System.Data.SqlDbType.Int);
                        command.Parameters.Add("@NumberSets", System.Data.SqlDbType.Int);
                        command.Parameters.Add("@LiftOrderNumber", System.Data.SqlDbType.Int);
                        command.Parameters.Add("@LiftNameID", System.Data.SqlDbType.Int);
                        command.Parameters["@WorkoutID"].Value = WorkoutID;
                        command.Parameters["@NumberSets"].Value = lift.Sets;
                        command.Parameters["@LiftOrderNumber"].Value = lift.LiftOrderNumber;
                        command.Parameters["@LiftNameID"].Value = lift.LiftNameID;
                        reader = command.ExecuteReader();
                        reader.Close();

                        //Get the new workoutid from the database
                        command = new SqlCommand("SELECT MAX(LiftID) AS LiftID FROM lift.Lift WHERE WorkoutID = @WorkoutID;", conn);
                        command.Parameters.Add("@WorkoutID", System.Data.SqlDbType.Int);
                        command.Parameters["@WorkoutID"].Value = WorkoutID;
                        reader = command.ExecuteReader();
                        reader.Read();
                        int LiftID = (int)reader["LiftID"];
                        reader.Close();

                        foreach(var set in lift.SetList)
                        {
                            command = new SqlCommand("INSERT INTO lift.LiftSet VALUES (COALESCE((SELECT MAX(SetID) + 1 AS SetID FROM lift.LiftSet), 1), @LiftID, @Repetitions, @Weight, @SetOrderNumber);", conn);
                            command.Parameters.Add("@LiftID", System.Data.SqlDbType.Int);
                            command.Parameters.Add("@Repetitions", System.Data.SqlDbType.Int);
                            command.Parameters.Add("@Weight", System.Data.SqlDbType.Int);
                            command.Parameters.Add("@SetOrderNumber", System.Data.SqlDbType.Int);
                            command.Parameters["@LiftID"].Value = LiftID;
                            command.Parameters["@Repetitions"].Value = set.Repetitions;
                            command.Parameters["@Weight"].Value = set.Weight;
                            command.Parameters["@SetOrderNumber"].Value = set.SetOrderNumber;
                            reader = command.ExecuteReader();
                            reader.Close();
                        }
                    };
                }
                else
                {
                    string error = ErrorCreator("Session Token: " + workout.SessionToken + " Was Not Verified");
                    return StatusCode(403, error);
                }


                return StatusCode(200, workout.Lifts[0].Sets);
            }
            catch(Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

    class Workout
    {
        public int SessionToken { get; set; }
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
        public int Sets { get; set; }
        public int LiftOrderNumber { get; set; }
        public int LiftNameID { get; set; }
        public string LiftName { get; set; }
        public List<Set> SetList { get; set; }

        public Lift()
        {
            SetList = new List<Set>();
        }

        public Lift(int sets, int liftOrderNumber, int liftNameID, string liftName)
        {
            Sets = sets;
            LiftOrderNumber = liftOrderNumber;
            LiftNameID = liftNameID;
            LiftName = liftName;
            SetList = new List<Set>();
        }
    }

    class Set
    {
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int SetOrderNumber { get; set; }

        public Set()
        {

        }

        public Set(int repetitions, int weight, int setOrderNumber)
        {
            Repetitions = repetitions;
            Weight = weight;
            SetOrderNumber = setOrderNumber;
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
        if (reader.HasRows)
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
