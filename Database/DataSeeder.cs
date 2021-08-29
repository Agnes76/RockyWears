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
                    var productData = File.ReadAllText(Path.Combine(dirDb, "json", "product.json"));
                    var productList = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products.AddRangeAsync(productList);
                }
                //if (!context.Contacts.Any())
                //{
                //    var contactData = File.ReadAllText(Path.Combine(dirDb , "json","contact.json"));
                //    var contactList = JsonConvert.DeserializeObject<List<Contact>>(contactData);
                //    await context.Contacts.AddRangeAsync(contactList);
                //}
                //if (!context.Categories.Any())
                //{
                //    var categoryData = File.ReadAllText(Path.Combine(dirDb ,"json","category.json"));
                //    var categoryList = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                //    await context.Categories.AddRangeAsync(categoryList);
                //}
                //if (!context.Images.Any())
                //{
                //    var imageData = File.ReadAllText(Path.Combine(dirDb + "json","image.json"));
                //    var imageList = JsonConvert.DeserializeObject<List<Image>>(imageData);
                //    await context.Images.AddRangeAsync(imageList);
                //}
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        
    }
}
