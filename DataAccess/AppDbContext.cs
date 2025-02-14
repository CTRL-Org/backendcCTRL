using Microsoft.EntityFrameworkCore;
using backendcCTRL.Models;

namespace backendcCTRL.Data
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

            // Ensuring table names match PostgreSQL naming conventions
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<HealthStats>().ToTable("HealthStats");

            // Relationships
            modelBuilder.Entity<Patient>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserID);

            modelBuilder.Entity<Appointment>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(a => a.PatientID);

            modelBuilder.Entity<HealthStats>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(h => h.PatientID);
        }
    }
}
