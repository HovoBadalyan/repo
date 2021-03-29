using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWnd.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWnd.DAL.Configuration
{
    class CategorySalesFor1997Configuration : IEntityTypeConfiguration<CategorySalesFor1997>
    {
        public void Configure(EntityTypeBuilder<CategorySalesFor1997> entity)
        {
            entity.HasNoKey();

            entity.ToView("Category Sales for 1997");
              
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.CategorySales).HasColumnType("money");
        }
    }
}
