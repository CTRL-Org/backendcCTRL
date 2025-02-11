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
            return _context.HealthStats.ToList();
        }

        public HealthStats GetHealthStatById(int id)
        {
            var healthStat = _context.HealthStats.FirstOrDefault(h => h.StatID == id);
            if (healthStat == null)
            {
                throw new KeyNotFoundException($"HealthStat with ID {id} not found.");
            }
            return healthStat;
        }

        public HealthStats CreateHealthStat(HealthStats healthStats)
        {
            _context.HealthStats.Add(healthStats);
            _context.SaveChanges();
            return healthStats;
        }

        public bool DeleteHealthStat(int id)
        {
            var healthStat = _context.HealthStats.Find(id);
            if (healthStat == null)
                return false;

            _context.HealthStats.Remove(healthStat);
            _context.SaveChanges();
            return true;
        }
    }
}
