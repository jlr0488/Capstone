﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gitripped.API
{
  [Route("api/GetWorkoutList")]
public class GetWorkoutList : Controller
{
    // GET: api/<controller>

    // GET api/Workout
    [HttpGet]
    public IActionResult GET(int tok)
    {
        try
        {
            SqlConnection conn = Helper.OpenSqlConnection();
            int UserID;
            if ((UserID = Helper.CheckSessionToken(tok, conn)) != -1)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM lift.Workout WHERE UserID = @UserID;", conn);
                command.Parameters.Add("@UserID", System.Data.SqlDbType.Int);
                command.Parameters["@UserID"].Value = UserID;
                SqlDataReader reader = command.ExecuteReader();
                List<GWorkout> workoutList = new List<GWorkout>();
                while (reader.Read())
                {
                    GWorkout workout = new GWorkout();
                    workout.WorkoutID = (int)reader["WorkoutID"];
                    workout.UserID = (int)reader["UserID"];
                    workout.NumberLifts = (int)reader["NumberLifts"];
                    workout.WorkoutComplete = reader["WorkoutComplete"].ToString();
                    workout.StartDateTime = (DateTime)reader["StartDatetime"];
                    workout.CompleteDateTime = (DateTime)reader["CompleteDatetime"];
                    workoutList.Add(workout);
                }

                var message = JsonConvert.SerializeObject(workoutList);
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
            return StatusCode(500, E.Message);
        }
    }
}
}