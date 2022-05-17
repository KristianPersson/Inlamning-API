using Microsoft.AspNetCore.Mvc;

namespace Inlamning_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private static List<Customer> customers = new List<Customer>
        {
                new Customer
                {
                    Id = 1,
                    FirstName = "Kristian",
                    LastName =  "Persson",
                    Email = "KristianP@domain.com",
                    PassWord = "Lösenord123!",
                    Adresses = "Adress 1"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Hilda",
                    LastName =  "Roman",
                    Email = "HildaR@domain.com",
                    PassWord = "Hejhej123!",
                    Adresses = "vägen 1"
                }

        };

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = customers.Find(h => h.Id == id);
            if (customer == null)
                return BadRequest("Customer not found.");
            return Ok(customer);
        }
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            customers.Add(customer);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            var customer = customers.Find(x => x.Id == request.Id);
            if (customer == null)
                return BadRequest("Customer not found.");
            
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Email = request.Email;
            customer.PassWord = request.PassWord;
            customer.Adresses = request.Adresses;

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> Delete(int id)
        {
            var customer = customers.Find(x => x.Id == id);
            if (customer == null)
                return BadRequest("Customer not found.");
            customers.Remove(customer);
            return Ok(customers);
        }





    }
}
