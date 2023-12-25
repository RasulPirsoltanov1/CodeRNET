using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJsonSerializer.Models
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
    }

    public class PhoneNumber
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    public class Root2
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public Address address { get; set; }
        public List<PhoneNumber> phoneNumber { get; set; }
    }


}
