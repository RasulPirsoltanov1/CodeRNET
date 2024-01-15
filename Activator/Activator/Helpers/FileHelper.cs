using CsvHelper;
using Custom_Activator.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Activator.Helpers
{
    public class FileHelper
    {
        public void FileReader()
        {
            var directory = Directory.GetCurrentDirectory() + @"../../../../";
            var category = (Category)Activator.CreateInstance(typeof(Category));
            var order = (Order)Activator.CreateInstance(typeof(Order));
            var product = (Product)Activator.CreateInstance(typeof(Product));
            var employee = (Employee)Activator.CreateInstance(typeof(Employee));


            var filePath = directory + "/file.csv";
            if (!System.IO.File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (category.GetType().Name == fields[0].Trim())
                    {
                        category.Names.Add(fields[1]);
                        category.Names.Add(fields[2]);
                    }
                    else if (product.GetType().Name == fields[0].Trim())
                    {
                        product.Name = fields[1];
                        product.Description = fields[2];
                        product.Price = Convert.ToInt32(fields[3]);
                        product.Stock = Convert.ToInt32(fields[4]);
                    }
                    else if (order.GetType().Name == fields[0].Trim())
                    {
                        order.Description = fields[2];
                        order.Count = Convert.ToInt32(fields[1]);
                    }
                    else if (employee.GetType().Name == fields[0].Trim())
                    {
                        employee.Names.Add(fields[1]);
                        employee.Names.Add(fields[2]);
                    }

                }

            }
            Console.WriteLine("-------------- Order -------------- ");
            Console.WriteLine();


            Console.WriteLine("Description : " + order.Description);
            Console.WriteLine("Count : "+order.Count);
            Console.WriteLine("-------------- Product -------------- ");
            Console.WriteLine();

            Console.WriteLine("Name : " + product.Name);
            Console.WriteLine("Description : " + product.Description);
            Console.WriteLine("Price : " + product.Price);
            Console.WriteLine("Stock : " + product.Stock);
            Console.WriteLine("-------------- Emplooyes-------------- ");
            Console.WriteLine();

            foreach (var item in employee?.Names)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();

            Console.WriteLine("-------------- Categories -------------- ");

            foreach (var item in category?.Names)
            {
                Console.Write(item + ",");
            }

        }
    }



}
