using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }
    public class AppDbContextFactory
    {
        IHttpContextAccessor _httpContextAccessor { get; set; }
        IConfiguration _configuration { get; set; }
        public AppDbContextFactory(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public AppDbContext CreateContext()
        {
            var tenantId = _httpContextAccessor.HttpContext!.Request.Headers["Tenant-Id"].FirstOrDefault();
            var connectionString = _configuration.GetConnectionString("Default");
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new AppDbContext(optionBuilder.Options);
        }

    }
}
