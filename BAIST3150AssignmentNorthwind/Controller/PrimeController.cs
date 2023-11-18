using Microsoft.AspNetCore.Mvc;
using BAIST3150AssignmentNorthwind.TechnicalServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIST3150AssignmentNorthwind.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        // GET: api/<PrimeController>
        [HttpGet]
        public string Get()
        {
            string trueOrFalse = "True";
            return trueOrFalse;
        }

        // GET api/<PrimeController>/5
        [HttpGet("{number}")]
        public string Get(int number)
        {
            string trueOrFalse;
            Customers customers = new Customers();
            if (customers.IsPrime(number) == true)
            {
               trueOrFalse = "This is a Prime Number";
            }
            else
            {
                trueOrFalse = "This is not a Prime Number";
            }
            return trueOrFalse;
        }

        // POST api/<PrimeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrimeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrimeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
