using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class OrderDetailsExtendedConfiguration : IEntityTypeConfiguration<OrderDetailsExtended>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsExtended> entity)
        {
            entity.HasNoKey();

            entity.ToView("Order Details Extended");

            entity.Property(e => e.ExtendedPrice).HasColumnType("money");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
