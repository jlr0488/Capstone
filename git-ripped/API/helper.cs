using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace gitripped.API
{
    public class Helper
    {
        public static SqlConnection OpenSqlConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=tcp:gitripped.database.windows.net,1433;Initial Catalog=gitripped;Persist Security Info=False;User ID=joshrobbins;Password=TempPass1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=True";
            conn.Open();
            return conn;
        }

        public static int CheckSessionToken(int token, SqlConnection conn)
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

        public static string ErrorCreator(string error)
        {
            string message = "{\"Error\":\"" + error + "\"}";
            return message;
        }
    }



    class GWorkout
    {
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public int NumberLifts { get; set; }
        public string WorkoutComplete { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime CompleteDateTime { get; set; }
        public List<GLift> Lifts { get; set; }

        public GWorkout()
        {
            Lifts = new List<GLift>();
        }
    }

    public class GLift
    {
        public int LiftID { get; set; }
        public int WorkoutID { get; set; }
        public int Sets { get; set; }
        public int LiftOrderNumber { get; set; }
        public int LiftNameID { get; set; }
        public string LiftName { get; set; }
        public List<GSet> SetList { get; set; }

        public GLift()
        {
            SetList = new List<GSet>();
        }

        public GLift(int liftID, int workoutID, int sets, int liftOrderNumber, int liftNameID, string liftName)
        {
            LiftID = liftID;
            WorkoutID = workoutID;
            Sets = sets;
            LiftOrderNumber = liftOrderNumber;
            LiftNameID = liftNameID;
            LiftName = liftName;
            SetList = new List<GSet>();
        }
    }

    public class GSet
    {
        public int SetID { get; set; }
        public int LiftID { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int SetOrderNumber { get; set; }

        public GSet()
        {

        }

        public GSet(int setID, int liftID, int repetitions, int weight, int setOrderNumber)
        {
            SetID = setID;
            LiftID = liftID;
            Repetitions = repetitions;
            Weight = weight;
            SetOrderNumber = setOrderNumber;
        }
    }

    class SWorkout
    {
        public int SessionToken { get; set; }
        public int NumberLifts { get; set; }
        public string WorkoutComplete { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime CompleteDateTime { get; set; }
        public List<SLift> Lifts { get; set; }

        public SWorkout()
        {
            Lifts = new List<SLift>();
        }
    }

    class SLift
    {
        public int Sets { get; set; }
        public int LiftOrderNumber { get; set; }
        public int LiftNameID { get; set; }
        public string LiftName { get; set; }
        public List<SSet> SetList { get; set; }

        public SLift()
        {
            SetList = new List<SSet>();
        }

        public SLift(int sets, int liftOrderNumber, int liftNameID, string liftName)
        {
            Sets = sets;
            LiftOrderNumber = liftOrderNumber;
            LiftNameID = liftNameID;
            LiftName = liftName;
            SetList = new List<SSet>();
        }
    }

    class SSet
    {
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int SetOrderNumber { get; set; }

        public SSet()
        {

        }

        public SSet(int repetitions, int weight, int setOrderNumber)
        {
            Repetitions = repetitions;
            Weight = weight;
            SetOrderNumber = setOrderNumber;
        }
    }

}
