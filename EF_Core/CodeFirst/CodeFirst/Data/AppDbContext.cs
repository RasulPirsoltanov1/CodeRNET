using CodeFirst.Mapping;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CategoryMapping)));


            modelBuilder.Entity<Product>().Property(x=>x.Name).HasMaxLength(40).IsRequired(true);

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(7,2)").IsRequired(false);
            modelBuilder.Entity<Product>().Property(x => x.UnitInStock).HasColumnType("smallint").IsRequired(false);


            modelBuilder.Entity<Product>().HasOne(p=>p.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(70);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NG2G057;Database=CodeFirstEfCore;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
