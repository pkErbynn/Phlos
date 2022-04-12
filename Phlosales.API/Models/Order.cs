using System.ComponentModel.DataAnnotations;

namespace Phlosales.API.Models
{
 
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
