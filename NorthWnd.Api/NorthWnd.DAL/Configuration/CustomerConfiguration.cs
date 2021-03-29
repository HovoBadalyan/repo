using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.CompanyName, "CompanyName");

            entity.HasIndex(e => e.PostalCode, "PostalCode");

            entity.HasIndex(e => e.Region, "Region");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(5)
                .HasColumnName("CustomerID")
                .IsFixedLength(true);

            entity.Property(e => e.Address).HasMaxLength(60);

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ContactName).HasMaxLength(30);

            entity.Property(e => e.ContactTitle).HasMaxLength(30);

            entity.Property(e => e.Country).HasMaxLength(15);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);
        }
    }
}
