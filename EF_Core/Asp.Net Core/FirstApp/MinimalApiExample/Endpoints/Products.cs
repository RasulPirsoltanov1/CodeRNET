using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using MiddlewareApp.Dto_s;
using MinimalApiExample.Services;

namespace MiddlewareApp.Endpoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var x = app.MapGroup("products");
            x.MapGet("/", async (IProductService productService) =>
            {
                return Results.Ok(await GetProducts(productService));
            });
            x.MapPost("/",(IProductService productService) =>
            {
                AddProduct(productService);
                return Results.Ok();
            });
        }


        public void AddProduct(IProductService productService)
        {
            productService.Create(new Dto_s.Product
            {
                Name = "test"
            });
        }
        public async Task<List<Product>> GetProducts(IProductService productService)
        {
            return await productService.GetAll();
        }
    }
}
