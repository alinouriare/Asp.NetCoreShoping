using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoping.DAL.EF.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Category).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ImageUrl).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500).IsRequired();
        }
    }
}
