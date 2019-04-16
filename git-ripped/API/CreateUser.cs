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
    [Route("api/CreateUser")]
    public class CreateUser : Controller
    {

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]JObject json)
        {
            try
            {
                Account account = JsonConvert.DeserializeObject<Account>(json.ToString());
                SqlConnection conn = OpenSqlConnection();
                    //Create the workout in the database with the max + 1 workoutid
                    SqlCommand command = new SqlCommand("INSERT INTO usr.Account(username, email, firstname, lastname, createdatetime) VALUES (@UserName, @Email, @FirstName, @LastName, GetDate());", conn);
                    command.Parameters.Add("@UserName", System.Data.SqlDbType.Char);
                    command.Parameters["@UserName"].Value = account.UserName;
                    command.Parameters.Add("@Email", System.Data.SqlDbType.Char);
                    command.Parameters["@Email"].Value = account.Email;
                    command.Parameters.Add("@FirstName", System.Data.SqlDbType.Char);
                    command.Parameters["@FirstName"].Value = account.FirstName;
                    command.Parameters.Add("@LastName", System.Data.SqlDbType.Char);
                    command.Parameters["@LastName"].Value = account.LastName;
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();


                return StatusCode(201);
            }
            catch (Exception E)
            {
                return StatusCode(500, E.Message);
            }
        }

        class Account
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set;}
            public string LastName { get; set; }
            //public DateTime CreateDateTime { get; set; }
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

        static SqlConnection OpenSqlConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=tcp:gitripped.database.windows.net,1433;Initial Catalog=gitripped;Persist Security Info=False;User ID=joshrobbins;Password=TempPass1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;MultipleActiveResultSets=True";
            conn.Open();
            return conn;
        }

        static string ErrorCreator(string error)
        {
            string message = "{\"Error\":\"" + error + "\"}";
            return message;
        }

    }
}
