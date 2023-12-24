namespace Interface_Example.Models
{
    public interface IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();
    }
}