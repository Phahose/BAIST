using Microsoft.AspNetCore.Mvc;
using BAIST3150AssignmentNorthwind.TechnicalServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIST3150AssignmentNorthwind.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasetenController : ControllerBase
    {
        // GET: api/<BasetenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BasetenController>/5
        [HttpGet("{binaryNumber}")]
        public int Get(string binaryNumber)
        {
            Customers customer = new Customers();
            int decimalNumber = customer.ConvertToBaseTen(binaryNumber);

            return decimalNumber;
        }

        // POST api/<BasetenController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasetenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BasetenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
