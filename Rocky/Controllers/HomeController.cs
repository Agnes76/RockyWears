using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repository;

namespace Rocky.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepo;
        public IEnumerable<Product> Products { get; private set; }

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }

        public IActionResult Index()
        {
            Products = _productRepo.GetAllProducts();
            return View(Products);
        }

        public IActionResult Contact()
        {
            return View();
        } 
        public IActionResult About()
        {
            return View();
        }
    }
}
