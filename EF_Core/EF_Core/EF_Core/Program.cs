using EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace EF_Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            NorthwindContext _northwindContext = new NorthwindContext();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var categories = _northwindContext.Products.Include(x=>x.Category).AsNoTracking().ToList();
            stopwatch.Stop();
            _northwindContext.Categories.Add(new Category
            {
                CategoryName="new cat",
                Description="desc",
            });
            _northwindContext.SaveChanges();
            foreach (var item in categories)
            {
                Console.WriteLine("Product : "+item.ProductName);
                Console.WriteLine("Description : "+item?.Category?.Description);
            }
            Console.WriteLine("Performaance : "+stopwatch.ElapsedMilliseconds);
            
        }
    }
}
