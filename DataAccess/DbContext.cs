using Microsoft.EntityFrameworkCore;
namespace Backend.DataAccess
{
    public class AppDbContext : DbContext
    {
        // Constructor that uses the DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // Define DbSets for each table in your database
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HealthStats> HealthStats { get; set; }
    }
}