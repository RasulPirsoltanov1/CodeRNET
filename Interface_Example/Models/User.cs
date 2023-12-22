using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Example.Models
{
    internal class User : IAccount
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool PasswordChecker(string password)
        {
            int count = 0;

            Console.Write("Enter the string: ");

            for (int i = 0; i < password.Length; i++)
            {
                char.IsDigit(password[i]);
                char.IsLower(password[i]);
                char.IsUpper(password[i]);
                if ((password[i] >= '0') && (password[i] <= '9'))
                {
                    count++;
                }
            }
            if (password.Length > 8 &&
                count >= 1 &&
                password.ToCharArray().Where(c => c >= 'A' && c <= 'Z').Count() >= 1 &&
                password.ToCharArray().Where(c => c >= 'a' && c <= 'z').Count() >= 1)
            {
                Password = password;
                return true;
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($@"
name : {FullName}
email : {Email}
password : {Password}

");
        }
    }
}
