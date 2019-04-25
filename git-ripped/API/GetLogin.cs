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
    [Route("api/GetLogin")]
    public class GetLogin : Controller
    {
        // POST api/Workout
        [HttpPost]
        public IActionResult Post([FromBody]JObject json)
        {

            dynamic jsonResponse = json;
            string username = jsonResponse.Username;
            string password = jsonResponse.Password;

            try
            {
                SqlConnection conn = OpenSqlConnection();
                int UserID;
                if ((UserID = CheckLogin(username, password, conn)) != -1)
                {

                    // deletes old token if it exists
                    SqlCommand command = new SqlCommand("SELECT * FROM usr.SessionToken WHERE UserID = @UserID",conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        command = new SqlCommand("DELETE FROM usr.SessionToken WHERE UserID = @UserID", conn);
                        command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                        command.Parameters["@UserID"].Value = UserID;
                        reader = command.ExecuteReader();
                    }

                    // creates and assigns the new token
                    command = new SqlCommand("INSERT INTO usr.SessionToken(SessionToken, UserID, Active, CreatedOn) VALUES((SELECT MAX(SessionToken) + 1 FROM usr.SessionToken), @UserID, 1, GetDate());", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    reader = command.ExecuteReader();

                    // gets the token
                    command = new SqlCommand("Select SessionToken From usr.SessionToken WHERE UserID = @UserID", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        int token = (int)reader["SessionToken"];
                        reader.Close();

                        var message = JsonConvert.SerializeObject(token);
                        return StatusCode(200, message);

                    }
                    else
                    {
                        string error = ErrorCreator("Session token was not created for this session");
                        reader.Close();
                        return StatusCode(404, error);
                    }
                }
                else
                {
                    string message = "{\"Error\":\"Incorrect Username and/or Password\"}";
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

        static int CheckLogin(string username, string password, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand("Select UserID From usr.Account WHERE Username = @UserName", conn);
            command.Parameters.Add("@UserName", System.Data.SqlDbType.Char);
            command.Parameters["@UserName"].Value = username;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int UserID_a = (int)reader["UserID"];
                reader.Close();

                command = new SqlCommand("Select HashedPassword From usr.Password WHERE UserID = @UserID", conn);
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                command.Parameters["@UserID"].Value = UserID_a;
                reader = command.ExecuteReader();
                reader.Read();
                string testPass = (string)reader["HashedPassword"];
                reader.Close();

                if (testPass == password)
                {
                    return UserID_a;
                }
                else
                {
                    return -1;
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
