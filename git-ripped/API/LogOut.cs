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
    [Route("api/Logout")]
    public class LogOut : Controller
    {
        [HttpGet]
        public IActionResult GET(int tok)
        {
            int token = tok;
            try
            {
                SqlConnection conn = OpenSqlConnection();
                int UserID;
                UserID = CheckLogin(token, conn);
                if (UserID != -1)
                {
                    SqlCommand command = new SqlCommand("UPDATE usr.SessionToken SET Active = 0 WHERE UserID = @UserID", conn);
                    command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                    command.Parameters["@UserID"].Value = UserID;
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(404, "Token has no associated UserID");
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

        public int CheckLogin(int token1, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand("Select UserID From usr.SessionToken WHERE (SessionToken = @SessionToken) AND (Active = 1)", conn);
            command.Parameters.Add("@SessionToken", System.Data.SqlDbType.Int);
            command.Parameters["@SessionToken"].Value = token1;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int ID = (int)reader["UserID"];
                reader.Close();

                return ID;
            }
            else
            {
                reader.Close();
                return -1;
            }

        }

    }
}
