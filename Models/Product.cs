using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Url is required")]
        public string? Url { get; set; }

        [Required(ErrorMessage = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Outside the allowed range")]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
