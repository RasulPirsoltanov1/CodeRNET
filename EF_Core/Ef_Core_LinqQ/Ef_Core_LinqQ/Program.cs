using Ef_Core_LinqQ.Data;
using Ef_Core_LinqQ.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ef_Core_LinqQ
{
    public class Program
    {
        private static ICategoryService _categoryService;
        public Program(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        static async Task Main(string[] args)
        {
            var configs = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false).Build();

            Console.WriteLine(configs.GetConnectionString("Default"));
            string connectionString = configs.GetConnectionString("Default");
            var serviceColecction = new ServiceCollection();
            var services =  ConfigureServices(serviceColecction, configs);
            var dbContext = services.BuildServiceProvider().GetRequiredService<ICategoryService>();
            var categories =await dbContext.GetAllAsync();
            foreach (var item in categories)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
