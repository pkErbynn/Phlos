using System.ComponentModel.DataAnnotations;


// UNUSED CLASS

namespace Phlosales.API.Models
{
 
    public class Order
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
