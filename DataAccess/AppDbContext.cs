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
        public DbSet<Staff> Staff { get; set; } = null!;
        public DbSet<Provider> Providers // Staff Table Configuration
        modelBuilder.Entity<Staff>()
            .HasKey(s => s.StaffID);
        
        modelBuilder.Entity<Staff>()
            .Property(s => s.StaffID)
            .HasColumnName("staffid");
        
        modelBuilder.Entity<Staff>()
            .Property(s => s.UserID)
            .HasColumnName("userid");
        
        modelBuilder.Entity<Staff>()
            .Property(s => s.ProviderID)
            .HasColumnName("providerid");
        
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
        
        // Provider Table Configuration
        modelBuilder.Entity<Provider>()
            .HasKey(p => p.ProviderID);
        
        modelBuilder.Entity<Provider>()
            .Property(p => p.ProviderID)
            .HasColumnName("providerid");
        
        modelBuilder.Entity<Provider>()
            .Property(p => p.UserID)
            .HasColumnName("userid");
        
        modelBuilder.Entity<Provider>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserID)
            .OnDelete(DeleteBehavior.Cascade);using System.ComponentModel.DataAnnotations;
            
            namespace backendcCTRL.Models
            {
                public class Provider// Staff Table Configuration
                modelBuilder.Entity<Staff>()
                    .HasKey(s => s.StaffID);
                
                modelBuilder.Entity<Staff>()
                    .Property(s => s.StaffID)
                    .HasColumnName("staffid");
                
                modelBuilder.Entity<Staff>()
                    .Property(s => s.UserID)
                    .HasColumnName("userid");
                
                modelBuilder.Entity<Staff>()
                    .Property(s => s.ProviderID)
                    .HasColumnName("providerid");
                
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
                
                // Provider Table Configuration
                modelBuilder.Entity<Provider>()
                    .HasKey(p => p.ProviderID);
                
                modelBuilder.Entity<Provider>()
                    .Property(p => p.ProviderID)
                    .HasColumnName("providerid");
                
                modelBuilder.Entity<Provider>()
                    .Property(p => p.UserID)
                    .HasColumnName("userid");
                
                modelBuilder.Entity<Provider>()
                    .HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserID)
                    .OnDelete(DeleteBehavior.Cascade);// Create provider user
                    var providerUser = new User
                    {
                        Role = "Provider",
                        Username = "provider1",
                        Password = "provider123",
                        Email = "provider@example.com"
                    };
                    context.Users.Add(providerUser);
                    context.SaveChanges();
                    
                    var provider = new Provider
                    {
                        UserID = providerUser.UserID,
                        LicenseNumber = "LIC123456",
                        Speciality = "General Practitioner"
                    };
                    context.Providers.Add(provider);
                    context.SaveChanges();
                    
                    // Create staff user
                    var staffUser = new User
                    {
                        Role = "Staff",
                        Username = "staff1",
                        Password = "staff123",
                        Email = "staff@example.com"
                    };
                    context.Users.Add(staffUser);
                    context.SaveChanges();
                    
                    var staff = new Staff
                    {
                        UserID = staffUser.UserID,
                        ProviderID = provider.ProviderID,
                        Department = "Reception",
                        Gender = "Female",
                        IDNumber = "9501011234567"
                    };
                    context.Staff.Add(staff);
                    context.SaveChanges();
                {
                    [Key]
                    public int ProviderID { get; set; }
            
                    [Required]
                    public int UserID { get; set; }
                    public User User { get; set; }
            
                    public string? LicenseNumber { get; set; }
                    public string? Speciality { get; set; }
            
                    public ICollection<Staff>? Staff { get; set; }
                }
            }{ get; set; } = null!;

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
