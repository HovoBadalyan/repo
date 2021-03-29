using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class SummaryOfSalesByQuarterConfiguration : IEntityTypeConfiguration<SummaryOfSalesByQuarter>
    {
        public void Configure(EntityTypeBuilder<SummaryOfSalesByQuarter> entity)
        {
            entity.HasNoKey();

            entity.ToView("Summary of Sales by Quarter");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.Property(e => e.ShippedDate).HasColumnType("datetime");

            entity.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}
