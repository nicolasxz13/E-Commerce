namespace E_Commerce.Models
{
    public class HomeIndexView
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
