using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesCompaniesAPI.Entities
{
    public class GameCompanyDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=GameCompanyDb;Trusted_Connection=True;";
        public DbSet<GameCompany> GameCompanies { get; set; }
        public DbSet<HqAddress> HqAddresses { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCompany>()
                .Property(gc => gc.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Game>()
                .Property(g => g.Name)
                .IsRequired();

            modelBuilder.Entity<HqAddress>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<HqAddress>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
