using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ECommerseContext _context;

        public CustomerController(ECommerseContext context)
        {
            _context = context;
        }

        [HttpGet("customers")]
        public IActionResult Index()
        {
            Customer_ListCustomerView x = new Customer_ListCustomerView();
            x.Customers = _context.Customers.ToList();
            return View(x);
        }

        [HttpPost("customers/create")]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CreatedAt = DateTime.Now;
                customer.UpdatedAt = DateTime.Now;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Customer_ListCustomerView x = new Customer_ListCustomerView();
                x.Customer = customer;
                return View("Index", x);
            }
        }

        [HttpPost("customer/{id}/destroy")]
        public IActionResult Delete(int id)
        {
            Customer? customer = _context.Customers.SingleOrDefault(a => a.Id == id);
            if (customer != null)
            {
                List<Order>? orders = _context.Orders.Where(a => a.Customer.Id == id).ToList();
                if (orders.Any())
                {
                    _context.Orders.RemoveRange(orders);
                }
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
