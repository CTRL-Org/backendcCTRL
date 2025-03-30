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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly match table names with PostgreSQL
            modelBuilder.Entity<User>().ToTable("app_user");
            modelBuilder.Entity<Patient>().ToTable("patient");
            modelBuilder.Entity<Appointment>().ToTable("appointment");
            modelBuilder.Entity<HealthStats>().ToTable("healthstats");

            // User Table Configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .Property(u => u.UserID)
                .HasColumnName("userid");

            // Patient Table Configuration
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientID);

            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientID)
                .HasColumnName("patientid");

            modelBuilder.Entity<Patient>()
                .Property(p => p.UserID)
                .HasColumnName("userid");

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Patient -> Appointments
            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.AppointmentID);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Patient -> HealthStats
            modelBuilder.Entity<HealthStats>()
                .HasKey(h => h.StatID);

            modelBuilder.Entity<HealthStats>()
                .HasOne(h => h.Patient)
                .WithMany()
                .HasForeignKey(h => h.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
