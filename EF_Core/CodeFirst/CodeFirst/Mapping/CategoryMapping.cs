using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Kategoriyalar");
            builder.Property(x => x.Name).HasMaxLength(90).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(900).IsRequired(false);
        }
    }
}
