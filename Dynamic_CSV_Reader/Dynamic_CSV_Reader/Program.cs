using System.Formats.Asn1;
using System.Globalization;
using System;
using CsvHelper;
using Dynamic_CSV_Reader.Models;

namespace Dynamic_CSV_Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            using (var reader = new StreamReader(@"..\..\..\file.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    list.Add(values[0]);
                }
            }

            var classes = typeof(Base).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Base)));
            Category category = Activator.CreateInstance<Category>();
            Employee employee = Activator.CreateInstance<Employee>();
            Order order = Activator.CreateInstance<Order>();
            Product product = Activator.CreateInstance<Product>();

            for (var i = 0; i < list.Count; i++)
            {
                var datas = String.Join(" ", list[i].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)).Split(',');

                for (int k = 0; k < datas.Length; k++)
                {
                    if ("Category" == datas[k]) //how can i do it automatic?
                    {
                        for (var j = 1; j < datas.Length; j++)
                        {
                            category.Name.Add(datas[j]);
                        }
                    }
                    else if (datas[k] == "Employee")
                    {
                        for (var j = 1; j < datas.Length; j++)
                        {
                            employee.Name.Add(datas[j]);
                        }
                    }
                    else if (datas[k] == "Order")
                    {
                        for (var j = 1; j < datas.Length; j++)
                        {
                            order.Total = Convert.ToInt32(datas[1]);
                            order.Name = datas[2];
                        }
                    }
                    else if (datas[k] == "Product")
                    {
                        if (datas[k].Length < 5)
                        {
                            throw new Exception("");
                        }
                        for (var j = 1; j < datas.Length; j++)
                        {
                            product.Name = datas[1];
                            product.Description = datas[2];
                            product.Price = Convert.ToInt32(datas[3]);
                            product.Stock = Convert.ToInt32(datas[4]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("----------Categories------------");
            Console.Write("Names : ");
            foreach (var item1 in category.Name)
            {
                Console.Write(item1);
                if (item1 != category.Name.Last())
                    Console.Write(",");
            }
            Console.WriteLine("\n");
            Console.WriteLine();
            Console.WriteLine("----------Employees------------");
            Console.Write("Names : ");
            foreach (var item1 in employee.Name)
            {
                Console.Write(item1);
                if (item1 != employee.Name.Last())
                    Console.Write(",");
            }
            Console.WriteLine("\n");
            Console.WriteLine("----------Order------------");
            Console.WriteLine("Name: " + order.Name + "   | Total: " + order.Total);
            Console.WriteLine();
            Console.WriteLine("----------Product------------");
            Console.WriteLine("Name: " + product.Name + "   |  Price: " + product.Price);
            Console.WriteLine("Description: " + product.Description + "   |  Stock: " + product.Stock);
            Console.WriteLine();


        }
    }
}