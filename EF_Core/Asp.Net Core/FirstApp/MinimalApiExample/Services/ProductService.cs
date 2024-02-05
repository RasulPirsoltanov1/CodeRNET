using MiddlewareApp.Dto_s;

namespace MinimalApiExample.Services
{
    public interface IProductService
    {
        Task Create(Product product);
        Task<List<Product>> GetAll();
    }
    public class ProductService : IProductService
    {
        static List<Product> products = new List<Product>();
        public async Task Create(Product product)
        {
            products.Add(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return products;
        }
    }
}
