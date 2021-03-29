using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class OrdersQryConfiguration : IEntityTypeConfiguration<OrdersQry>
    {
        public void Configure(EntityTypeBuilder<OrdersQry> entity)
        {
            entity.HasNoKey();

            entity.ToView("Orders Qry");

            entity.Property(e => e.Address).HasMaxLength(60);

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID")
                .IsFixedLength(true);

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.Property(e => e.Freight).HasColumnType("money");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.RequiredDate).HasColumnType("datetime");

            entity.Property(e => e.ShipAddress).HasMaxLength(60);

            entity.Property(e => e.ShipCity).HasMaxLength(15);

            entity.Property(e => e.ShipCountry).HasMaxLength(15);

            entity.Property(e => e.ShipName).HasMaxLength(40);

            entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

            entity.Property(e => e.ShipRegion).HasMaxLength(15);

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");
        }
    }
}
