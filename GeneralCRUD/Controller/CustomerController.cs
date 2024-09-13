using GeneralCRUD.Models;
using GeneralCRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeneralCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Customer data is missing.");

            _customerService.InsertCustomer(customer);
            return CreatedAtAction(nameof(GetCustomers), new { id = customer.customer_id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null) return NotFound();

            _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            var existingCustomer = _customerService.GetCustomerById(id);
            if (existingCustomer == null) return NotFound();

            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
