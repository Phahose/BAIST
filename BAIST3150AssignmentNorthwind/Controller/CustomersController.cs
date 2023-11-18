using Microsoft.AspNetCore.Mvc;
using BAIST3150AssignmentNorthwind.Domain;
using BAIST3150AssignmentNorthwind.TechnicalServices;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BAIST3150AssignmentNorthwind.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> customerList = new List<Customer>(); 
            Customers customers = new Customers();
            customerList = customers.GetCustomers();
            return customerList;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{customerid}")]
        public Customer Get(string customerid)
        {
            Customers customers = new Customers();
            Customer customer;
            customer = customers.GetCustomer(customerid);
            return customer;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
