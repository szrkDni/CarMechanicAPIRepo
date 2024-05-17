using CarMechanicAPI.Data;
using CarMechanicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarMechanicAPI
{
    public class CustomerService : ICustomerService
    {
        private CarMechanicContext _context;
        //private ILogger<CustomerService> _logger;

        public CustomerService(CarMechanicContext context/*, ILogger<CustomerService> logger*/)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task Add(Customer newCustomer)
        {
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();

            //_logger.LogInformation("Customer added {@Customer}", newCustomer);
        }

        public async Task Delete(Guid id)
        {
            var customer = await GetById(id);
            
            _context.Customers.Remove(customer);
            
            //_logger.LogInformation("Customer deleted {@Customer}", customer);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);

           // _logger.LogInformation("Customer found {@Customer}", customer);
            
            return customer;
        }

        public async Task Update(Customer newCustomer)
        {
            var customer = await GetById(newCustomer.Id);
            customer.CustomerLocation = newCustomer.CustomerLocation;
            customer.CustomerName = newCustomer.CustomerName;
            customer.CustomerEmail = newCustomer.CustomerEmail;

            //_logger.LogInformation("Customer updated {@Customer}", customer);

            await _context.SaveChangesAsync();
        }
    }
}
