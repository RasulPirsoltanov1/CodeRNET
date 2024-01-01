using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_CSV_Reader.Models
{
    public class Base
    {

    }
    public class Category: Base
    {
        public List<string> Name { get; set; } =new List<string>();
    }
    public class Employee: Base
    {
        public List<string>? Name { get; set; } = new List<string>();
    }
    public class Order: Base
    {
        public int Total { get; set; }
        public string? Name { get; set; }
    }
    public class Product: Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
    }
}
