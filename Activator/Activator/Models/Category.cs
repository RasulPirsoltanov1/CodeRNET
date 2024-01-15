using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Activator.Models
{
    public class Category
    {
        public Category()
        {
            Names = new List<string>();
        }
        public List<string>? Names { get; set; }
    }
    public class Product
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
    public class Employee
    {
        public Employee()
        {
            Names = new List<string>();
        }
        public List<string>? Names { get; set; }
    }
    public class Order
    {
        public string? Description { get; set; }
        public int Count { get; set; }
    }
}
