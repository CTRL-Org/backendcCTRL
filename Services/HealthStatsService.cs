using Microsoft.EntityFrameworkCore;
using backendcCTRL.DataAccess;
using backendcCTRL.Models;
using backendcCTRL.Services.Interfaces;

namespace backendcCTRL.Services
{
    public class HealthStatsService : IHealthStatsService
    {
        private readonly AppDbContext _context;

        public HealthStatsService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<HealthStats> GetAllHealthStats()
        {
            return _context.HealthStats.Include(h => h.Patient).ToList();
        }

        public HealthStats? GetHealthStatsById(int id)
        {
            return _context
                .HealthStats
                .Include(h => h.Patient)
                .FirstOrDefault(h => h.StatID == id);
        }

        public HealthStats? GetHealthStatsByPatientId(int patientId)
        {
            return _context
                .HealthStats
                .Include(h => h.Patient)
                .FirstOrDefault(h => h.PatientID == patientId);
        }

        public HealthStats CreateHealthStats(HealthStats healthStats)
        {
            healthStats.Timestamp = DateTime.UtcNow;
            _context.HealthStats.Add (healthStats);
            _context.SaveChanges();
            return healthStats;
        }

        public HealthStats? UpdateHealthStats(HealthStats healthStats)
        {
            var existingStats = _context.HealthStats.Find(healthStats.StatID);
            if (existingStats == null) return null;

            existingStats.DataType = healthStats.DataType;
            existingStats.Value = healthStats.Value;
            existingStats.Timestamp = DateTime.UtcNow;

            _context.SaveChanges();
            return existingStats;
        }

        public bool DeleteHealthStats(int id)
        {
            var healthStats = _context.HealthStats.Find(id);
            if (healthStats == null) return false;

            _context.HealthStats.Remove (healthStats);
            _context.SaveChanges();
            return true;
        }
    }
}
