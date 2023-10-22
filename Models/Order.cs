using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Outside the allowed range")]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Customer Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
