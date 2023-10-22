using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ECommerseContext _context;

        public HomeController(ECommerseContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Customer> customers = _context.Customers
                .OrderByDescending(a => a.CreatedAt)
                .Take(5)
                .ToList();
            List<Product> products = _context.Products
                .OrderByDescending(a => a.CreatedAt)
                .Take(5)
                .ToList();
            List<Order> orders = _context.Orders
                .OrderByDescending(a => a.CreatedAt)
                .Take(5)
                .ToList();
            HomeIndexView homeIndexView = new HomeIndexView()
            {
                Customers = customers,
                Products = products,
                Orders = orders
            };
            return View(homeIndexView);
        }
    }
}
