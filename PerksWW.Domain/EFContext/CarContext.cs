using Microsoft.EntityFrameworkCore;
using PerksWW.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerksWW.Domain.EFContext
{
   public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasIndex(e => e.CarId);
                entity.Property(e => e.CarId).ValueGeneratedOnAdd();
            });
        }
    }
}
