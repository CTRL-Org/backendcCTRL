using Microsoft.AspNetCore.Mvc;
using backendcCTRL.Services.Interfaces;
using backendcCTRL.Models;
using Microsoft.Extensions.Logging;

namespace backendcCTRL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthStatsController : ControllerBase
    {
        private readonly IHealthStatsService _healthStatsService;
        private readonly ILogger<HealthStatsController> _logger;

        public HealthStatsController(IHealthStatsService healthStatsService, ILogger<HealthStatsController> logger)
        {
            _healthStatsService = healthStatsService;
            _logger = logger;
        }

        // GET: api/HealthStats
        [HttpGet]
        public IActionResult GetAllHealthStats()
        {
            try
            {
                var healthStats = _healthStatsService.GetAllHealthStats();
                _logger.LogInformation($"Retrieved {healthStats.Count()} health stats records");
                return Ok(healthStats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving health stats: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/HealthStats/{id}
        [HttpGet("{id}")]
        public IActionResult GetHealthStatsById(int id)
        {
            try
            {
                var healthStats = _healthStatsService.GetHealthStatsById(id);
                if (healthStats == null)
                {
                    _logger.LogWarning($"Health stats with ID {id} not found");
                    return NotFound();
                }
                return Ok(healthStats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving health stats with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/HealthStats/patient/{patientId}
        [HttpGet("patient/{patientId}")]
        public IActionResult GetHealthStatsByPatientId(int patientId)
        {
            try
            {
                var healthStats = _healthStatsService.GetHealthStatsByPatientId(patientId);
                if (healthStats == null)
                {
                    _logger.LogWarning($"Health stats for patient ID {patientId} not found");
                    return NotFound();
                }
                return Ok(healthStats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving health stats for patient ID {patientId}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/HealthStats
        [HttpPost]
        public IActionResult CreateHealthStats([FromBody] HealthStats healthStats)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdStats = _healthStatsService.CreateHealthStats(healthStats);
                _logger.LogInformation($"Created health stats with ID: {createdStats.StatID}");
                return CreatedAtAction(nameof(GetHealthStatsById), new { id = createdStats.StatID }, createdStats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating health stats: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/HealthStats
        [HttpPut]
        public IActionResult UpdateHealthStats([FromBody] HealthStats healthStats)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedStats = _healthStatsService.UpdateHealthStats(healthStats);
                if (updatedStats == null)
                {
                    _logger.LogWarning($"Health stats with ID {healthStats.StatID} not found");
                    return NotFound();
                }

                _logger.LogInformation($"Updated health stats with ID: {updatedStats.StatID}");
                return Ok(updatedStats);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating health stats: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/HealthStats/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHealthStats(int id)
        {
            try
            {
                var result = _healthStatsService.DeleteHealthStats(id);
                if (!result)
                {
                    _logger.LogWarning($"Health stats with ID {id} not found");
                    return NotFound();
                }

                _logger.LogInformation($"Deleted health stats with ID: {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting health stats with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
