namespace E_Commerce.Models
{
    public class OrderIndexView
    {
        public Order_ListCustomer_ListProductView Order_ListCustomer_ListProductView { get; set; } =
            new Order_ListCustomer_ListProductView();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
