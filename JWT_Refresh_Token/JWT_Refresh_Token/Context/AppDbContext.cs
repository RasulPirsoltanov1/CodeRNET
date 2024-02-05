using JWT_Refresh_Token.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT_Refresh_Token.Context
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions) { }
        public virtual DbSet<UserRefreshTokens> UserRefreshTokens{ get; set; }
        public virtual DbSet<UserRegister> UserRegisters{ get; set; }
    }
}
