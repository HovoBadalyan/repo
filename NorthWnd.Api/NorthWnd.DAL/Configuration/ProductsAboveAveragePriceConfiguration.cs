using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class ProductsAboveAveragePriceConfiguration : IEntityTypeConfiguration<ProductsAboveAveragePrice>
    {
        public void Configure(EntityTypeBuilder<ProductsAboveAveragePrice> entity)
        {
            entity.HasNoKey();

            entity.ToView("Products Above Average Price");

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
