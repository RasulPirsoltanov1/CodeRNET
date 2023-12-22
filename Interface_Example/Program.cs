using Interface_Example.Models;

namespace Interface_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Test", "Test@gmail.com", "DSsSss12JKH.ASDF");
            user.ShowInfo();
        }
    }
}