using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;
// using YourNamespace.Models;

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
    public IActionResult CreateHealthStat([FromBody] HealthStats healthStat)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
