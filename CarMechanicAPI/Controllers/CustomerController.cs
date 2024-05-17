using CarMechanicAPI.Data;
using CarMechanicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;

namespace CarMechanicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpPost]

        public async Task<ActionResult> NewCustomer([FromBody] Customer newCustomer)
        {
            var existingCustomer = await _customerService.GetById(newCustomer.Id);

            if (existingCustomer is not null)
            {
                return Conflict("Customer already exist");
            }

            _customerService.Add(newCustomer);

            return Ok(newCustomer);
        }


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAll();

            return Ok(customers);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Customer>> GetCustomer(Guid customerId)
        {
            var customer = await _customerService.GetById(customerId);

            if(customer is null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCustomer(Guid id)
        {
            var customerToDelete = await _customerService.GetById(id);

            if(customerToDelete is null)
            {
                return NotFound("Customer not found");
            }

            await _customerService.Delete(id);

            return Ok("Customer deleted successfully");
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateExistingCustomer([FromBody] Customer newCustomerDetails,  Guid id)
        {
            if(id != newCustomerDetails.Id)
            {
                return BadRequest("Customer id cannot be changed");
            }
            
            var existingCustomer = await _customerService.GetById(id);

            if (existingCustomer is null)
            {
                return NotFound("customer not found");
            }

            await _customerService.Update(existingCustomer);

            return Ok("Customer updated successfully");

        }

    }
}
