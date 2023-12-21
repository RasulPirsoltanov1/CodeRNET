using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public class Stuff
    {
        public string Firstname { get; set; } = "Rasul";
        public string Lastname { get; set; } = "Pirsoltanov";
        public string Email { get; set; } = "rasul@gmail.com";
        public string Phone { get; set; } = "3304402340";
        public string Address { get; set; } = "Azerbaijan";



        public Stuff()
        {
            Console.WriteLine($@"
FirstName : {Firstname}
Lastname : {Lastname}
Email : {Email}
Phone : {Phone}
Address : {Address}");
        }
    }
}
