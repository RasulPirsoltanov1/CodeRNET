using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool GenerateEmail { get; set; }

        public string CreateEmail()
        {
            return $"{this.FirstName}.{this.LastName}@example.com";
        }
        public override string ToString()
        {
            var x = "";
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                x+=@$"

{propertyInfo.Name} : {propertyInfo.GetValue(this)}

";
            }
            return x;
        }
    }
}
