using Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Rocky
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scoped = host.Services.CreateScope())
            {
                var webHostEnv = scoped.ServiceProvider.GetService<IWebHostEnvironment>();
                string dirDb = webHostEnv.WebRootPath;
                var seed = scoped.ServiceProvider.GetRequiredService<DataSeeder>();
                _ = seed.Seed(dirDb);
            };

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
