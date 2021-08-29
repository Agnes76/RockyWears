using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repository;

namespace Rocky.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepo;
        public IEnumerable<Product> Products { get; private set; }
        public Product Product { get; private set; }

        public ProductController(ILogger<HomeController> logger, IProductRepository productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }
        public IActionResult Index()
       {
            Products = _productRepo.GetAllProducts();
            return View(Products);
        }
        public IActionResult Details(int id)
        {
           Product = _productRepo.GetProductById(id);
            return View(Product);
        }
        public IActionResult SearchByCategory(string searchQuery)
        {
            Products = _productRepo.GetAllProducts();
            List<Product> productsByCategory = new List<Product>();
            if (string.IsNullOrEmpty(searchQuery))
            {
                return NotFound();
            }
            foreach (var item in Products)
            {
                if (item.Category.Name == searchQuery)
                {
                    productsByCategory.Add(item);
                }
            }
            return View(productsByCategory);
        }
       
    }
}
