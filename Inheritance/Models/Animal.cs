using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public  class Animal
    {
        public string Name { get; set; }
        public virtual void Display()
        {
            Console.WriteLine($"overrided  {Name}");
        }
        public virtual void Display(int xc)
        {
            Console.WriteLine($"overrided  {Name}");
        }
    }
    public class Cat:Animal
    {
        public Cat()
        {
            this.Name = "Pisik";
        }

        public void test()
        {
            Console.WriteLine("test is vorking");
        }
        public override void Display()
        {
            base.Display();
        }
        public override void Display(int xc)
        {
            base.Display();
        }
    }
}
