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

namespace gitripped.API
{
    [Route("api/CreateAttributes")]
    public class CreateUserAttributes : Controller
    {
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]JObject json)
        {
            try
            {
                Attributes attributes = JsonConvert.DeserializeObject<Attributes>(json.ToString());
                SqlConnection conn = OpenSqlConnection();
                int UserID;
                if ((UserID = CheckSessionToken(attributes.SessionToken, conn)) != -1)
                {
                    //Create the workout in the database with the max + 1 workoutid
                    SqlCommand command = new SqlCommand("INSERT INTO usr.Attributes VALUES (@UserID, @Height, @StartingWeight, @CurrentWeight, @GoalWeight, @Gender, @Birthday, @WaistMeasure, @ArmMeasure, @ChestMeasure, @BackMeasure, @LegMeasure);", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    command.Parameters.Add("@Height", System.Data.SqlDbType.Int);
                    command.Parameters["@Height"].Value = attributes.Height;
                    command.Parameters.Add("@StartingWeight", System.Data.SqlDbType.Decimal);
                    command.Parameters["@StartingWeight"].Precision = 5;
                    command.Parameters["@StartingWeight"].Scale = 2;
                    command.Parameters["@StartingWeight"].Value = attributes.StartingWeight;
                    command.Parameters.Add("@CurrentWeight", System.Data.SqlDbType.Decimal);
                    command.Parameters["@CurrentWeight"].Value = attributes.CurrentWeight;
                    command.Parameters["@CurrentWeight"].Precision = 5;
                    command.Parameters["@CurrentWeight"].Scale = 2;
                    command.Parameters.Add("@GoalWeight", System.Data.SqlDbType.Decimal);
                    command.Parameters["@GoalWeight"].Value = attributes.GoalWeight;
                    command.Parameters["@GoalWeight"].Precision = 5;
                    command.Parameters["@GoalWeight"].Scale = 2;
                    command.Parameters.Add("@Gender", System.Data.SqlDbType.Char);
                    command.Parameters["@Gender"].Value = attributes.Gender;
                    command.Parameters.Add("@Birthday", System.Data.SqlDbType.DateTime);
                    command.Parameters["@Birthday"].Value = attributes.Birthday;
                    command.Parameters.Add("@WaistMeasure", System.Data.SqlDbType.Decimal);
                    command.Parameters["@WaistMeasure"].Value = attributes.WaistMeasure;
                    command.Parameters["@WaistMeasure"].Precision = 5;
                    command.Parameters["@WaistMeasure"].Scale = 2;
                    command.Parameters.Add("@ArmMeasure", System.Data.SqlDbType.Decimal);
                    command.Parameters["@ArmMeasure"].Value = attributes.ArmMeasure;
                    command.Parameters["@ArmMeasure"].Precision = 5;
                    command.Parameters["@ArmMeasure"].Scale = 2;
                    command.Parameters.Add("@ChestMeasure", System.Data.SqlDbType.Decimal);
                    command.Parameters["@ChestMeasure"].Value = attributes.ChestMeasure;
                    command.Parameters["@ChestMeasure"].Precision = 5;
                    command.Parameters["@ChestMeasure"].Scale = 2;
                    command.Parameters.Add("@BackMeasure", System.Data.SqlDbType.Decimal);
                    command.Parameters["@BackMeasure"].Value = attributes.BackMeasure;
                    command.Parameters["@BackMeasure"].Precision = 5;
                    command.Parameters["@BackMeasure"].Scale = 2;
                    command.Parameters.Add("@LegMeasure", System.Data.SqlDbType.Decimal);
                    command.Parameters["@LegMeasure"].Value = attributes.LegMeasure;
                    command.Parameters["@LegMeasure"].Precision = 5;
                    command.Parameters["@LegMeasure"].Scale = 2;
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
                else
                {
                    string error = ErrorCreator("Session Token: " + attributes.SessionToken + " Was Not Verified");
                    return StatusCode(403, error);
                }

                return StatusCode(200);

            }
            catch (Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        class Attributes
        {
            public int SessionToken { get; set; }
            public int Height { get; set; }
            public float StartingWeight { get; set; }
            public float CurrentWeight { get; set; }
            public float GoalWeight { get; set; }
            public string Gender { get; set; }
            //sql date is in this format: YYY-MM-DD, but can recieve date in the DD-MM-YYYY format as well
            public string Birthday { get; set; }
            public float WaistMeasure { get; set; }
            public float ArmMeasure { get; set; }
            public float ChestMeasure { get; set; }
            public float BackMeasure { get; set; }
            public float LegMeasure { get; set; }

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

