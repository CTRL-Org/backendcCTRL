using Microsoft.AspNetCore.Mvc;
using backendcCTRL.DTOs;
using backendcCTRL.Services.Interfaces;
using backendcCTRL.Models; 

[ApiController]
[Route("api/[controller]")]
public class HealthStatsController : ControllerBase
{
    private readonly IHealthStatsService _healthStatsService;

    public HealthStatsController(IHealthStatsService healthStatsService)
    {
        _healthStatsService = healthStatsService;
    }

    // GET: api/HealthStats
    [HttpGet]
    public IActionResult GetAllHealthStats()
    {
        var healthStats = _healthStatsService.GetAllHealthStats();
        return Ok(healthStats);
    }

    // GET: api/HealthStats/{id}
    [HttpGet("{id}")]
    public IActionResult GetHealthStatById(int id)
    {
        var healthStat = _healthStatsService.GetHealthStatById(id);
        if (healthStat == null)
        {
            return NotFound();
        }
        return Ok(healthStat);
    }

    // POST: api/HealthStats
    [HttpPost]
    public IActionResult CreateHealthStat([FromBody] CreateHealthStatDTO healthStatDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        // Map DTO to model
        var healthStat = new HealthStats
        {
            PatientID = healthStatDto.PatientID,
            DataType = healthStatDto.DataType,
            Value = healthStatDto.Value,
            Timestamp = healthStatDto.Timestamp // Or set DateTime.UtcNow here if needed
        };

        var createdHealthStat = _healthStatsService.CreateHealthStat(healthStat);
        return CreatedAtAction(nameof(GetHealthStatById), new { id = createdHealthStat.StatID }, createdHealthStat);
    }


    // DELETE: api/HealthStats/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteHealthStat(int id)
    {
        var isDeleted = _healthStatsService.DeleteHealthStat(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
