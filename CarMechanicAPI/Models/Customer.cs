using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarMechanicAPI.Models
{
    public class Customer
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3)]
        public string CustomerName { get; set; }
        [Required]
        [MinLength(5)]
        public string CustomerLocation { get; set; }
        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}
