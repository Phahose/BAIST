using BAIST3150AssignmentNorthwind.TechnicalServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIST3150AssignmentNorthwind.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasetwoController : ControllerBase
    {
        // GET: api/<BasetwoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "BaseTen", "BaseTwo" };
        }

        // GET api/<BasetwoController>/5
        [HttpGet("{basetenNumber}")]
        public string Get(int basetenNumber)
        {
            Customers customers = new Customers();
            string basetwoNumber = customers.ConvertToBaseTwo(basetenNumber);
            return basetwoNumber;
        }

        // POST api/<BasetwoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasetwoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BasetwoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
