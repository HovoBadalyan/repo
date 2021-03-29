using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class CustomerDemographicConfiguration : IEntityTypeConfiguration<CustomerDemographic>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographic> entity)
        {
            entity.HasKey(e => e.CustomerTypeId)
                  .IsClustered(false);

            entity.Property(e => e.CustomerTypeId)
                .HasMaxLength(10)
                .HasColumnName("CustomerTypeID")
                .IsFixedLength(true);

            entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
        }
    }
}
