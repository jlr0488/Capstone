using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gitripped.API
{
	[Route("api/LiftRecords/")]
	public class LiftRecords : Controller
	{
		// GET: api/<controller>
		[HttpGet]
		public IActionResult GET(int tok)
		{
			try
			{
				int UserID;
				SqlConnection conn = Helper.OpenSqlConnection();
				if ((UserID = Helper.CheckSessionToken(tok, conn)) != -1)
				{
					SqlCommand command = new SqlCommand("SELECT * FROM lift.LiftMax WHERE UserID = @UserID;", conn);
					command.Parameters.Add("UserID", System.Data.SqlDbType.Int);
					command.Parameters["UserID"].Value = UserID;
					SqlDataReader reader = command.ExecuteReader();
					List<MaxLiftItem> MaxLifts = new List<MaxLiftItem>();

					while (reader.Read())
					{
						MaxLiftItem item = new MaxLiftItem();
						item.Max = (int)reader["Max"];
						item.LiftNameID = (int)reader["LiftNameID"];
						item.LiftName = reader["LiftName"].ToString();
						MaxLifts.Add(item);
					}

					var message = JsonConvert.SerializeObject(MaxLifts);
					return StatusCode(200, message);
				}
				else
				{
					string message = "{\"Error\":\"Session Token: " + tok + " Was Not Verified\"}";
					return StatusCode(403, message);
				}
			}
			catch (Exception E)
			{
				return StatusCode(400, E.Message);
			}
		}
	}
}