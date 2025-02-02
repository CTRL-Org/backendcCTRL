using Microsoft.EntityFrameworkCore;
using backendcCTRL.Models;


namespace Backend.DataAccess  // Namespace should be properly structured
{
    public class AppDbContext : DbContext
    {
        // Constructor that takes DbContext options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets - tables in the database
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HealthStats> HealthStats { get; set; }
    }
}
