using Constructors.Models;

namespace Interface_Constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 12; i++)
            {
                Employee employee = new Employee("Rasul");

            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //create an object
            
        }
    }
}