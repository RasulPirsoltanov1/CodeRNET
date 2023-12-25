using CustomJsonSerializer.Extensions;
using CustomJsonSerializer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomJsonSerializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var json = @"{""isbn"": ""123-456-222"",  
 ""author"": 
    {
      ""lastname"": ""Doe"",
      ""firstname"": ""Jane""
    },
""editor"": 
    {
      ""lastname"": ""Smith"",
      ""firstname"": ""Jane""
    },
  ""title"": ""The Ultimate Database Study Guide"",    ""titasale"": ""The Ultimate Database Study Guide"",  

  ""category"": [""Non-Fiction"", ""Technology""]
 }";


            Root root = CustomConverter.Deserialize<Root>(json);
            string newJson = CustomConverter.Serializer<Root>(root);
            Console.WriteLine("\nNew Json\n" + newJson);
        }

    }
}
