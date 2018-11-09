using Dropdowns.Models;
using Microsoft.EntityFrameworkCore;

namespace Dropdowns.Data
{
    public class DropdownContext : DbContext
    {
        public DropdownContext(DbContextOptions<DropdownContext> options) : base(options)
        {
            // empty constructor          
        }

        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Contries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Dropdowns");

            modelBuilder.Entity<Corporation>().ToTable("Corporation");
            modelBuilder.Entity<Continent>().ToTable("Continent");
            modelBuilder.Entity<Country>().ToTable("Country");
        }
    }
}