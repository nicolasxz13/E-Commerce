namespace E_Commerce.Models
{
    public class Customer_ListCustomerView
    {
        public Customer Customer { get; set; } = new Customer();
        public List<Customer>? Customers { get; set; } = new List<Customer>();
    }
}
