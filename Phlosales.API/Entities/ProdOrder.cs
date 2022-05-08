using System.ComponentModel.DataAnnotations;

namespace Phlosales.API.Entities
{
    public class ProdOrder
    {
        [Required]
        public Guid ProdOrderId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
    }

    // poco
}
