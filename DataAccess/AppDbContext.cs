using Microsoft.EntityFrameworkCore;
using backendcCTRL.Models;

namespace backendcCTRL.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<HealthStats> HealthStats { get; set; } = null!;
        public DbSet<Provider> Providers { get; set; } = null!;
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<GlobalHealthStats> GlobalHealthStats { get; set; } = null!;
        public DbSet<SymptomsLog> SymptomsLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly match table names with PostgreSQL
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<HealthStats>().ToTable("HealthStats");
            modelBuilder.Entity<Provider>().ToTable("Provider");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<GlobalHealthStats>().ToTable("GlobalHealthStats");
            modelBuilder.Entity<SymptomsLog>().ToTable("SymptomsLog");

            // Configure relationships
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Provider)
                .WithMany()
                .HasForeignKey(a => a.ProviderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HealthStats>()
                .HasOne(h => h.Patient)
                .WithMany()
                .HasForeignKey(h => h.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Provider>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Provider)
                .WithMany(p => p.Staff)
                .HasForeignKey(s => s.ProviderID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SymptomsLog>()
                .HasOne(s => s.Patient)
                .WithMany()
                .HasForeignKey(s => s.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}