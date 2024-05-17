using CarMechanicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMechanicAPI.Data
{
    public class CarMechanicContext : DbContext
    {
        public CarMechanicContext(DbContextOptions<CarMechanicContext> options) 
            : base(options)
        {
            
        }
    
        public DbSet<Customer> Customers { get; set; }

    }


}
