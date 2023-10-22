using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ECommerseContext _context;

        public OrderController(ECommerseContext context)
        {
            _context = context;
        }

        [HttpGet("orders")]
        public IActionResult Index()
        {
            OrderIndexView orderIndexView = new OrderIndexView();
            orderIndexView.Order_ListCustomer_ListProductView.Products = _context.Products.ToList();
            orderIndexView.Order_ListCustomer_ListProductView.Customers =
                _context.Customers.ToList();
            orderIndexView.Orders = _context.Orders.ToList();
            return View(orderIndexView);
        }

        [HttpPost("orders/create")]
        public IActionResult Create(
            Order_ListCustomer_ListProductView order_ListCustomer_ListProductView
        )
        {
            if (ModelState.IsValid)
            {
                Customer? customer = _context.Customers.FirstOrDefault(
                    a => a.Id == order_ListCustomer_ListProductView.CustomerId
                );
                Product? product = _context.Products.FirstOrDefault(
                    a => a.Id == order_ListCustomer_ListProductView.ProductId
                );
                if (product != null && customer != null)
                {
                    if (product.Quantity > order_ListCustomer_ListProductView.ProductQuantity)
                    {
                        Order order = new Order()
                        {
                            Customer = customer,
                            Product = product,
                            Quantity = order_ListCustomer_ListProductView.ProductQuantity,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                        };

                        _context.Orders.Add(order);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(
                            "ProductQuantity",
                            "The quantity of the product is not enough."
                        );
                        OrderIndexView orderIndexView = new OrderIndexView();
                        orderIndexView.Order_ListCustomer_ListProductView =
                            order_ListCustomer_ListProductView;
                        orderIndexView.Order_ListCustomer_ListProductView.Products =
                            _context.Products.ToList();
                        orderIndexView.Order_ListCustomer_ListProductView.Customers =
                            _context.Customers.ToList();
                        orderIndexView.Orders = _context.Orders.ToList();
                        return View("Index", orderIndexView);
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                OrderIndexView orderIndexView = new OrderIndexView();
                orderIndexView.Order_ListCustomer_ListProductView =
                    order_ListCustomer_ListProductView;
                orderIndexView.Order_ListCustomer_ListProductView.Products =
                    _context.Products.ToList();
                orderIndexView.Order_ListCustomer_ListProductView.Customers =
                    _context.Customers.ToList();
                orderIndexView.Orders = _context.Orders.ToList();
                return View("Index", orderIndexView);
            }
        }
    }
}
