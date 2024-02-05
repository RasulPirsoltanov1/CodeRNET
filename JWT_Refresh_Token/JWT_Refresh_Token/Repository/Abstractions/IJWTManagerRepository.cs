using JWT_Refresh_Token.Models;
using System.Security.Claims;

namespace JWT_Refresh_Token.Repository.Abstractions
{
    public interface IJWTManagerRepository
    {
        Tokens GenerateToken(string userName);
        Tokens GenerateRefreshToken(string userName);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
