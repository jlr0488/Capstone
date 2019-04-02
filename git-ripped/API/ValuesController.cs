using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gitripped
{
    [Route("api/test")]
public class ValuesController : Controller
{
    // GET: api/<controller>
    [HttpGet("{ID}")]
    public string Get(int id)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "server=tcp:gitripped.database.windows.net,1433; Initial Catalog = gitripped_2019 - 03 - 06T15 - 47Z; Persist Security Info = False; User ID =zacherychambers2; Password =Xsvsyysk99; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
        conn.Open();
        SqlCommand command = new SqlCommand("Select * From usr.Account WHERE UserID = @id", conn);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int);
        command.Parameters["@id"].Value = id;
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        string Output = reader["Username"].ToString();
        conn.Close();
        return Output;
    }

    /*// GET api/<controller>/5
    [HttpGet("{temp}")]
    public string Get(int temp)
    {
        return temp.ToString();
    }*/

    // POST api/<controller>
    [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}
