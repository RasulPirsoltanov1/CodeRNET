using JWT_Refresh_Token.Models;

namespace JWT_Refresh_Token.Repository.Abstractions
{
    public interface IUserServiceRepository
    {
        Task<bool> IsValidUserAsync(UserLogin users);

        UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);

        UserRefreshTokens GetSavedRefreshTokens(string username, string refreshtoken);

        void DeleteUserRefreshTokens(string username, string refreshToken);
    }
}
