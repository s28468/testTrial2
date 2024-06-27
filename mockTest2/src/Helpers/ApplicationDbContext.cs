using Microsoft.EntityFrameworkCore;
using mockTest2.Models;

namespace mockTest2.Helpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<DriverCompetition> DriverCompetitions { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverCompetition>()
                .HasKey(dc => new { dc.DriverId, dc.CompetitionId });

            modelBuilder.Entity<DriverCompetition>()
                .HasOne(dc => dc.Driver)
                .WithMany()
                .HasForeignKey(dc => dc.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DriverCompetition>()
                .HasOne(dc => dc.Competition)
                .WithMany()
                .HasForeignKey(dc => dc.CompetitionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarManufacturer)
                .WithMany()
                .HasForeignKey(c => c.CarManufacturerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Car)
                .WithMany()
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .Property(c => c.ConcurrencyToken)
                .IsRowVersion();

            modelBuilder.Entity<Driver>()
                .Property(d => d.ConcurrencyToken)
                .IsRowVersion();

            modelBuilder.Entity<DriverCompetition>()
                .Property(dc => dc.ConcurrencyToken)
                .IsRowVersion();
        }
    }
}
