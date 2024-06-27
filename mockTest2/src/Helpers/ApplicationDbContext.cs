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
            modelBuilder.Entity<CarManufacturer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("CarManufacturers");
                entity.Property(e => e.Name)
                      .HasMaxLength(200)
                      .IsRequired();
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Cars");
                entity.Property(e => e.ModelName)
                      .HasMaxLength(200)
                      .IsRequired();
                entity.Property(e => e.Number)
                      .IsRequired();

                entity.HasOne(c => c.CarManufacturer)
                      .WithMany()
                      .HasForeignKey(c => c.CarManufacturerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(c => c.ConcurrencyToken)
                      .IsRowVersion();
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Drivers");
                entity.Property(e => e.FirstName)
                      .HasMaxLength(200)
                      .IsRequired();
                entity.Property(e => e.LastName)
                      .HasMaxLength(200)
                      .IsRequired();
                entity.Property(e => e.Birthday)
                      .IsRequired();

                entity.HasOne(d => d.Car)
                      .WithMany()
                      .HasForeignKey(d => d.CarId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(d => d.ConcurrencyToken)
                      .IsRowVersion();
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Competitions");
                entity.Property(e => e.Name)
                      .HasMaxLength(200)
                      .IsRequired();
            });

            modelBuilder.Entity<DriverCompetition>(entity =>
            {
                entity.HasKey(dc => new { dc.DriverId, dc.CompetitionId });
                entity.ToTable("DriverCompetitions");
                entity.Property(dc => dc.Date)
                      .IsRequired();

                entity.HasOne(dc => dc.Driver)
                      .WithMany()
                      .HasForeignKey(dc => dc.DriverId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dc => dc.Competition)
                      .WithMany()
                      .HasForeignKey(dc => dc.CompetitionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(dc => dc.ConcurrencyToken)
                      .IsRowVersion();
            });
        }
    }
}
