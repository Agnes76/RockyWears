using System.Collections.Generic;
using Models;


namespace Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int productId);
    }
}
