using JWT_Refresh_Token.Models;
using JWT_Refresh_Token.Repository.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWT_Refresh_Token.Repository.Concrets
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _iconfiguration;

        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public Tokens GenerateToken(string userName)
        {
            return GenerateJWTTokens(userName);
        }

        public Tokens GenerateRefreshToken(string username)
        {
            return GenerateJWTTokens(username);
        }

        public Tokens GenerateJWTTokens(string userName)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                };
                var token = new JwtSecurityToken(issuer: _iconfiguration["JWT:Issuer"],
                    audience: _iconfiguration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credentials
                    );
                return new Tokens
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = GenerateRefreshToken()
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
