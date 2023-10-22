using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Order_ListCustomer_ListProductView
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Outside the allowed range")]
        public int ProductQuantity { get; set; }

        public List<Product>? Products { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}
