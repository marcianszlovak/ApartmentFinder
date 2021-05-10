using System.Collections.Generic;
using ApartmentFinder.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentFinder.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Location> Locations { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<Apartment>().ToTable("Apartments");
            modelBuilder.Entity<Apartment>().HasKey(a => a.Id);
            modelBuilder.Entity<Apartment>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Apartment>().Property(a => a.Description).IsRequired();


            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Location>().HasKey(l => l.Id);
            modelBuilder.Entity<Location>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().HasMany(a => a.Apartments).WithOne(l => l.Location)
                .HasForeignKey(l => l.LocationId);
        }
    }
}