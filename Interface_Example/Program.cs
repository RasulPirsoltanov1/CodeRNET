using Interface_Example.Models;

namespace Interface_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.FullName = "Test";
            user.Id = new Guid();
            user.Email = "Test@gmail.com";
            user.PasswordChecker("DSsSF1JKH.ASDF");
            user.ShowInfo();
        }
    }
}