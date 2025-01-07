// need to define interface for service


using YourNamespace.Models;
using YourNamespace.Services.Interfaces;
using YourNamespace.Data;

namespace YourNamespace.Services
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
            return _context.HealthStats.FirstOrDefault(h => h.StatID == id);
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
