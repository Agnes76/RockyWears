using System.Collections.Generic;
using System.Linq;
using Database;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
           return  _context.Set<Product>().Include(p => p.Image).ToList();
        }

        public Product GetProductById(int productId)
        {
            Product product = _context.Products
                .Include(prod => prod.Image)
                .Include(prod => prod.Category)
                .FirstOrDefault(p => p.Id == productId);
            return product;
            //return _context.Set<Product>().FirstOrDefault(p => p.Id == productId);
        }
    }
}
