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

            // Explicitly match table names with PostgreSQL
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Patient>().ToTable("patient");
            modelBuilder.Entity<Appointment>().ToTable("appointment");
            modelBuilder.Entity<HealthStats>().ToTable("healthstats");

            // User Table Configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .Property(u => u.UserID)
                .HasColumnName("userid")
                .ValueGeneratedNever(); // Prevents auto-generation if manually assigned

            // Patient Table Configuration
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientID);

            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientID)
                .HasColumnName("patientid")
                .ValueGeneratedNever(); // Ensures manual assignment (BIGINT)

            modelBuilder.Entity<Patient>()
                .Property(p => p.UserID)
                .HasColumnName("userid");

            // One-to-One: User -> Patient
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient) // Added navigation in User model
                .HasForeignKey<Patient>(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Patient -> Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Patient -> HealthStats
            modelBuilder.Entity<HealthStats>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.HealthStats)
                .HasForeignKey(h => h.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
