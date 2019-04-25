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
    [Route("api/ChangePassword")]
    public class ChangePassword : Controller
    {
        // POST api/Workout
        [HttpPost]
        public IActionResult Post([FromBody]JObject json)
        {

            dynamic jsonResponse = json;
            string username = jsonResponse.Username;
            string password = jsonResponse.Password;
            string newPassword = jsonResponse.NewPassword;

            try
            {
                SqlConnection conn = OpenSqlConnection();
                int UserID;
                if ((UserID = CheckLogin(username, password, conn)) != -1)
                {
                    SqlCommand command = new SqlCommand("UPDATE usr.Password SET HashedPassword = @NewPassword WHERE UserID = @UserID", conn);
                    command.Parameters.Add("@NewPassword", System.Data.SqlDbType.Char);
                    command.Parameters["@NewPassword"].Value = newPassword;
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    command.ExecuteNonQuery();
                    return StatusCode(200, "{\"Message\":\"Password Changed.\"}");
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

                command = new SqlCommand("Select UserID From usr.Password WHERE HashedPassword = @Password", conn);
                command.Parameters.Add("@Password", System.Data.SqlDbType.Char);
                command.Parameters["@Password"].Value = password;
                reader = command.ExecuteReader();
                reader.Read();
                int UserID_b = (int)reader["UserID"];
                reader.Close();

                if (UserID_a == UserID_b)
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

