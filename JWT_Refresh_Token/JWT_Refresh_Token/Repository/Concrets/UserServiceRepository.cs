using JWT_Refresh_Token.Context;
using JWT_Refresh_Token.Models;
using JWT_Refresh_Token.Repository.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace JWT_Refresh_Token.Repository.Concrets
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private readonly AppDbContext _db;

        public UserServiceRepository(UserManager<IdentityUser> userManager, AppDbContext db)
        {
            _db = db;
        }

        public UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user)
        {
            _db.UserRefreshTokens.Add(user);
            _db.SaveChanges();
            return user;
        }

        public void DeleteUserRefreshTokens(string username, string refreshToken)
        {
            var item = _db.UserRefreshTokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken);
            if (item != null)
            {
                _db.UserRefreshTokens.Remove(item);
            }
        }

        public UserRefreshTokens GetSavedRefreshTokens(string username, string refreshToken)
        {
            return _db.UserRefreshTokens.FirstOrDefault(x => x.UserName == username && x.RefreshToken == refreshToken && x.IsActive == true);
        }

        public async Task<bool> IsValidUserAsync(UserLogin users)
        {
            var u = _db.UserRegisters.FirstOrDefault(o => o.Email == users.Email && o.Password == users.Password);

            if (u != null)
                return true;
            else
                return false;
        }
    }
}
