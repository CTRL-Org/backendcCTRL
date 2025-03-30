using backendcCTRL.Models;

namespace backendcCTRL.Services.Interfaces
{
    public interface IHealthStatsService
    {
        IEnumerable<HealthStats> GetAllHealthStats();
        HealthStats? GetHealthStatsById(int id);
        HealthStats? GetHealthStatsByPatientId(int patientId);
        HealthStats CreateHealthStats(HealthStats healthStats);
        HealthStats? UpdateHealthStats(HealthStats healthStats);
        bool DeleteHealthStats(int id);
    }
}
