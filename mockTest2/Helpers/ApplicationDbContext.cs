using Microsoft.EntityFrameworkCore;
using mockTest2.Models;

namespace mockTest2.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<DriverCompetition> DriverCompetitions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverCompetition>()
                .HasKey(dc => new { dc.DriverId, dc.CompetitionId });

            modelBuilder.Entity<DriverCompetition>()
                .HasOne(dc => dc.Driver)
                .WithMany(d => d.DriverCompetitions)
                .HasForeignKey(dc => dc.DriverId);

            modelBuilder.Entity<DriverCompetition>()
                .HasOne(dc => dc.Competition)
                .WithMany(c => c.DriverCompetitions)
                .HasForeignKey(dc => dc.CompetitionId);
        }
    }
}