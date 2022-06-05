using Microsoft.AspNetCore.Mvc;
using Inlamning_API.Model;
using Inlamning_API.Filters;

namespace Inlamning_API.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private static List<CustomerModel> customers = new List<CustomerModel>
        {
                    new CustomerModel
                {
                    Id = 1,
                    FirstName = "Kristian",
                    LastName =  "Persson",
                    Email = "KristianP@domain.com",
                    PassWord = "Lösenord123!",
                    Adresses = "Adress 1"
                },
                new CustomerModel
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
        public async Task<ActionResult<List<CustomerModel>>> Get()
        {
           
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> Get(int id)
        {
            var customer = customers.Find(h => h.Id == id);
            if (customer == null)
                return BadRequest("Customer not found.");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<CustomerModel>>> AddCustomer(CustomerModel customer)
        {
            customers.Add(customer);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<ActionResult<List<CustomerModel>>> UpdateCustomer(CustomerModel request)
        {
            var customer = customers.Find(x => x.Id == request.Id);
            if (customer == null)
                return NotFound("Customer not found.");
            
            customer.Id = request.Id;

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CustomerModel>>> Delete(int id)
        {
            var customer = customers.Find(x => x.Id == id);
            if (customer == null)
                return BadRequest("Customer not found.");
            customers.Remove(customer);
            return Ok(customers);
        }
    }
}

[ApiKey]
[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{

    private static List<ProductModel> products = new List<ProductModel>
        {
                    new ProductModel
                {
                    Id = 1,
                    ProductName = "Apple",
                    ProductDescription =  "A red fruit",
                    Price = 10,
                    Category = "Fruits"
                },
                    new ProductModel
                {
                    Id  = 2,
                    ProductName = "Banana",
                    ProductDescription =  "A yellow fruit",
                    Price = 20,
                    Category = "Fruits"
                }


        };

    [HttpGet]
    public async Task<ActionResult<List<ProductModel>>> Get()
    {

        return Ok(products);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ProductModel>> Get(int id)
    {
        var product = products.Find(h => h.Id == id);
        if (product == null)
            return BadRequest("Product not found.");
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<List<ProductModel>>> AddProduct(ProductModel product)
    {
        products.Add(product);
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<List<ProductModel>>> UpdateProduct(ProductModel request)
    {
        var product = products.Find(x => x.Id == request.Id);
        if (product == null)
            return NotFound("Product not found.");

        product.Id = request.Id;

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ProductModel>>> Delete(int id)
    {
        var product = products.Find(x => x.Id == id);
        if (product == null)
            return BadRequest("Product not found.");
        products.Remove(product);
        return Ok(products);
    }
}

[ApiKey]
[Route("api/[controller]")]
[ApiController]

public class OrderController : Controller
{

    private static List<OrderModel> orders = new List<OrderModel>
        {
                    new OrderModel
                {
                    UserId = 1,
                    FirstName = "Kristian",
                    LastName =  "Persson",
                    OrderTime = 10.20,
                    OrderStatus = "Ready for delivery",
                    ProductsOrder = "Apples, Oranges",
                    ProductQuantity = 10
                 },

                    new OrderModel
                {
                    UserId = 2,
                    FirstName = "Hilda",
                    LastName =  "Roman",
                    OrderTime = 11.30,
                    OrderStatus = "On its way",
                    ProductsOrder = "Apples, Oranges",
                    ProductQuantity = 20
                }


        };

    [HttpGet]
    public async Task<ActionResult<List<OrderModel>>> Get()
    {

        return Ok(orders);
    }

    [HttpGet("{UserId}")]
    public async Task<ActionResult<OrderModel>> Get(int id)
    {
        var order = orders.Find(h => h.UserId == id);
        if (order == null)
            return BadRequest("Order not found.");
        return Ok(orders);
    }

    [HttpPost]
    public async Task<ActionResult<List<OrderModel>>> AddOrder(OrderModel order)
    {
        orders.Add(order);
        return Ok(orders);
    }

    [HttpPut]
    public async Task<ActionResult<List<OrderModel>>> UpdateOrder(OrderModel request)
    {
        var order = orders.Find(x => x.UserId == request.UserId);
        if (order == null)
            return NotFound("Order not found.");

        order.UserId = request.UserId;

        return Ok(order);
    }

    [HttpDelete("{Userid}")]
    public async Task<ActionResult<List<OrderModel>>> Delete(int id)
    {
        var order = orders.Find(x => x.UserId == id);
        if (order == null)
            return BadRequest("Order not found.");
        orders.Remove(order);
        return Ok(orders);
    }
}