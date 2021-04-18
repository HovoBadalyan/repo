﻿// <auto-generated />
using Cofee_Machine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cofee_Machine.Migrations
{
    [DbContext(typeof(CofeeDbContext))]
    [Migration("20210417131658_price")]
    partial class price
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cofee_Machine.Models.CoffeeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Coffee")
                        .HasColumnType("float");

                    b.Property<string>("CoffeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Sugar")
                        .HasColumnType("float");

                    b.Property<double>("Water")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Coffees");
                });
#pragma warning restore 612, 618
        }
    }
}
