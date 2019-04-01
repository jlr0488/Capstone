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
    [Route("api/CreateWorkout")]
public class CreateWorkout : Controller
{


    // POST api/<controller>
    [HttpPost]
    public IActionResult Post([FromBody]JObject json)
    {
            Workout workout = JsonConvert.DeserializeObject<Workout>(json.ToString()); 


            return StatusCode(200, workout.Lifts[0].Sets);
    }

    class Workout
    {
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public int NumberLifts { get; set; }
        public string WorkoutComplete { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime CompleteDateTime { get; set; }
        public List<Lift> Lifts { get; set; }

        public Workout()
        {
            Lifts = new List<Lift>();
        }
    }

    class Lift
    {
        public int LiftID { get; set; }
        public int WorkoutID { get; set; }
        public int Sets { get; set; }
        public int LiftOrderNumber { get; set; }
        public int LiftNameID { get; set; }
        public string LiftName { get; set; }
        public List<Set> SetList { get; set; }

        public Lift()
        {
            SetList = new List<Set>();
        }

        public Lift(int liftID, int workoutID, int sets, int liftOrderNumber, int liftNameID, string liftName)
        {
            LiftID = liftID;
            WorkoutID = workoutID;
            Sets = sets;
            LiftOrderNumber = liftOrderNumber;
            LiftNameID = liftNameID;
            LiftName = liftName;
            SetList = new List<Set>();
        }
    }

    class Set
    {
        public int SetID { get; set; }
        public int LiftID { get; set; }
        public int Repetitions { get; set; }
        public int Weight { get; set; }
        public int SetOrderNumber { get; set; }

        public Set()
        {

        }

        public Set(int setID, int liftID, int repetitions, int weight, int setOrderNumber)
        {
            SetID = setID;
            LiftID = liftID;
            Repetitions = repetitions;
            Weight = weight;
            SetOrderNumber = setOrderNumber;
        }
    }

    }
}
