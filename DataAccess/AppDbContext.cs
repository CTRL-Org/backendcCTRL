using Microsoft.EntityFrameworkCore;
using backendcCTRL.Models;

namespace backendcCTRL.DataAccess 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HealthStats> HealthStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // table names match PostgreSQL naming conventions
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<HealthStats>().ToTable("HealthStats");

            // Patient -> User (One-to-One)
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany()  // Assuming one User can have multiple Patients
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent accidental deletions

            // Patient -> Appointments (One-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments) // Each patient can have multiple appointments
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Cascade); // If Patient is deleted, remove Appointments

            // Patient -> HealthStats (One-to-Many)
            modelBuilder.Entity<HealthStats>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.HealthStats) // Each patient can have multiple health records
                .HasForeignKey(h => h.PatientID)
                .OnDelete(DeleteBehavior.Cascade); // If Patient is deleted, remove HealthStats
        }
    }
}
