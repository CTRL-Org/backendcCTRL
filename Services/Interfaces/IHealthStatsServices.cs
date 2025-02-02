using backendcCTRL.Models;
using System.Collections.Generic;

namespace backendcCTRL.Services.Interfaces
{
    public interface IHealthStatsService
    {
        IEnumerable<HealthStats> GetAllHealthStats();

        HealthStats GetHealthStatById(int id);

        // Create a new health stat
        HealthStats CreateHealthStat(HealthStats healthStats);

        // Delete a health stat by ID
        bool DeleteHealthStat(int id);
    }
}