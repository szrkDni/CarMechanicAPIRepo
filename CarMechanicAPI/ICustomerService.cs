using CarMechanicAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace CarMechanicAPI
{
    public interface ICustomerService
    {
        Task Add(Customer customer);
        Task Delete(Guid id);
        Task<Customer> GetById(Guid id);
        Task<List<Customer>> GetAll();
        Task Update(Customer customer);


    }
}
