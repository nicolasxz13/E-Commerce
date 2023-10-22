using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product_ListProductView
    {
        public Product Product { get; set; } = new Product();
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
