using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;
using Newtonsoft.Json;

namespace Database
{
    public class DataSeeder
    {
        ApplicationDbContext context;
        private readonly ILogger<DataSeeder> _logger;

        public DataSeeder(ApplicationDbContext context, ILogger<DataSeeder> logger)
        {
            this.context = context;
            _logger = logger;
        }
        public async Task Seed(string dirDb)
        {
            try
            {
                context.Database.EnsureCreated();
                bool b = context.Products.Any();
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText(Path.Combine(dirDb + @"/json/product.json"));
                    var productList = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products.AddRangeAsync(productList);
                }
                


                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        
    }
}
