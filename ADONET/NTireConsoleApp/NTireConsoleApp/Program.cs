

using Business.Interfaces;
using Business.Services;
using Data.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        //ICategoryService categoryService = new CategoryService();
        //categoryService.Add(new Data.Entities.Category
        //{
        //    CategoryName = "Test",
        //    Description = "f;dsklnfakl;ds"
        //});


        //Console.WriteLine(categoryService.Get(1));

        //categoryService.Update(new Data.Entities.Category
        //{
        //    CategoryName = "ok",
        //    CategoryId = 2022,
        //    Description = "ok"

        //});

        //var categories = categoryService.GetAll();
        //foreach (var item in categories)
        //{
        //    Console.WriteLine(item.CategoryName);
        //}

        IProductService productService = new ProductService();
        
        foreach (var item in productService.GetAll())
        {
            Console.WriteLine(item.ProductName);
        }

        productService.Add(new Data.Entities.Product
        {
            ProductName = "Test",
        });
        Console.WriteLine(productService.Get(1).ProductName);

        foreach (var item in productService.GetAll())
        {
            Console.WriteLine(item.ProductName);
        }
    }
}