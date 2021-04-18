using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cofee_Machine.Models
{
    class CofeeDbContext : DbContext
    {
        public DbSet<CoffeeModel> Coffees { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=Coffee_MachineDb;Trusted_Connection=True;");
        }

    }
}
