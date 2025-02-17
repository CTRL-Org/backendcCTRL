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

            // Table naming to match PostgreSQL schema
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
                .ValueGeneratedNever(); 

            // Patient -> User (One-to-One)
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithMany()  
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict); 

            // Patient -> Appointments (One-to-Many)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Cascade);

            // Patient -> HealthStats (One-to-Many)
            modelBuilder.Entity<HealthStats>()
                .HasOne(h => h.Patient)
                .WithMany(p => p.HealthStats)
                .HasForeignKey(h => h.PatientID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
