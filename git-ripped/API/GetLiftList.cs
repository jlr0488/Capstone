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
	[Route("api/GetLiftList")]
	public class GetLiftList : Controller
	{
		// GET: api/<controller>
		[HttpGet]
		public IActionResult GET()
		{
			try
			{
				SqlConnection conn = Helper.OpenSqlConnection();
				SqlCommand command = new SqlCommand("SELECT * FROM lift.LiftList;", conn);
				SqlDataReader reader = command.ExecuteReader();
				List<LiftListItem> liftList = new List<LiftListItem>();
				while (reader.Read())
				{
					LiftListItem item = new LiftListItem();
					item.LiftNameID = (int)reader["LiftNameID"];
					item.LiftName = reader["LiftName"].ToString();
					if (!DBNull.Value.Equals(reader["PrimaryMuscleID"]))
					{
						item.PrimaryMuscleID = (int)reader["PrimaryMuscleID"];
					}
					if (!DBNull.Value.Equals(reader["SecondaryMuscleID"]))
					{
						item.SecondaryMuscleID = (int)reader["SecondaryMuscleID"];
					}
					if (!DBNull.Value.Equals(reader["PrimaryFatigueRating"]))
					{
						item.PrimaryFatigueRating = (int)reader["PrimaryFatigueRating"];
					}
					if (!DBNull.Value.Equals(reader["SecondaryFatigueRating"]))
					{
						item.SecondaryFatigueRating = (int)reader["SecondaryFatigueRating"];
					}
					liftList.Add(item);
				}

				var message = JsonConvert.SerializeObject(liftList);

				return StatusCode(200, message);
			}
			catch (Exception E)
			{
				return StatusCode(400, E.Message);
			}
		}
	}
}
