using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class ProductsByCategoryConfiguration : IEntityTypeConfiguration<ProductsByCategory>
    {
        public void Configure(EntityTypeBuilder<ProductsByCategory> entity)
        {
            entity.HasNoKey();

            entity.ToView("Products by Category");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
        }
    }
}
