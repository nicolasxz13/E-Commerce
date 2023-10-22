using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ECommerseContext _context;

        public ProductController(ECommerseContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public IActionResult Index()
        {
            Product_ListProductView x = new Product_ListProductView();
            x.Products = _context.Products.ToList();
            return View(x);
        }

        [HttpPost("products/create")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Product_ListProductView x = new Product_ListProductView();
                x.Product = product;
                return View("Index", x);
            }
        }
    }
}
