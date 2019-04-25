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

                SqlCommand command = new SqlCommand("SELECT * FROM usr.Account WHERE UserName = @UserName OR Email = @Email", conn);
                command.Parameters.Add("@UserName", System.Data.SqlDbType.Char);
                command.Parameters["@UserName"].Value = account.UserName;
                command.Parameters.Add("@Email", System.Data.SqlDbType.Char);
                command.Parameters["@Email"].Value = account.Email;
                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();

                    // for storing the new user data
                    command = new SqlCommand("INSERT INTO usr.Account(username, email, firstname, lastname, createdatetime) VALUES (@UserName, @Email, @FirstName, @LastName, GetDate());", conn);
                    command.Parameters.Add("@UserName", System.Data.SqlDbType.Char);
                    command.Parameters["@UserName"].Value = account.UserName;
                    command.Parameters.Add("@Email", System.Data.SqlDbType.Char);
                    command.Parameters["@Email"].Value = account.Email;
                    command.Parameters.Add("@FirstName", System.Data.SqlDbType.Char);
                    command.Parameters["@FirstName"].Value = account.FirstName;
                    command.Parameters.Add("@LastName", System.Data.SqlDbType.Char);
                    command.Parameters["@LastName"].Value = account.LastName;
                    reader = command.ExecuteReader();
                    reader.Close();

                    // for storing the new passowrd
                    command = new SqlCommand("INSERT INTO usr.Password (userID, HashedPassword) VALUES ((SELECT UserID FROM usr.Account WHERE username = @UserName), @Password);", conn);
                    command.Parameters.Add("@UserName", System.Data.SqlDbType.Char);
                    command.Parameters["@UserName"].Value = account.UserName;
                    command.Parameters.Add("@Password", System.Data.SqlDbType.Char);
                    command.Parameters["@Password"].Value = account.Password;
                    reader = command.ExecuteReader();
                    reader.Close();

                    return StatusCode(201);
                }
                else
                {
                    reader.Close();
                    return StatusCode(404, "UserName or Email already exists");
                }
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
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            //public DateTime CreateDateTime { get; set; }
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
