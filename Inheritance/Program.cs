using Inheritance.Models;
using System.Reflection;

namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var dictionary=new Dictionary<string, object>() {
                { "FirstName","Rasul"},
                { "Id",Guid.NewGuid()},
                { "LastName","Rasul"},
                { "Email","Rasul@gmail.com"},
                { "Gender","Kisi"},
                { "Phone","43563465"},
                { "Address","bAKU"},
                { "GenerateEmail",false},
            };
            Employee employee = new Employee();
            foreach (PropertyInfo info in employee.GetType().GetProperties())
            {
                if(dictionary.ContainsKey(info.Name))
                {
                    info.SetValue(employee,dictionary[info.Name]);
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(employee);
        }
    }
}