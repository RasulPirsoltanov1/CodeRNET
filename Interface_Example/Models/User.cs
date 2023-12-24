using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Example.Models
{
    internal class User : IAccount
    {
        public Guid Id
        {
            get;
        }
        public User(string email, string fullName, string pass)
        {
            Email = email;
            FullName = fullName;
            Id = new Guid();
            if (PasswordChecker(pass))
            {
                Password = pass;
            }
            else
            {
                throw new Exception("incorrect pass");
            }
        }
        public string FullName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        private string Password
        {
            get;
            set;
        }
        public bool PasswordChecker(string password)
        {
            if (password.Length > 8 &&
              password.ToCharArray().Where(x => char.IsDigit(x)).Count() >= 1 &&
              password.ToCharArray().Where(c => char.IsLower(c)).Count() >= 1 &&
              password.ToCharArray().Where(c => char.IsUpper(c)).Count() >= 1)
            {
                return true;
            }
            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine($@"
    
        name:{FullName}
        email:{Email}
        password:{Password}
            ");
        }
    }
}