using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_CSV_Reader.Models
{
    public class Category : Base
    {
        public List<string> Name { get; set; } = new List<string>();
    }
}
