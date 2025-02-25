[HttpPost("create-health-stat")]
public IActionResult CreateHealthStat([FromBody] CreateHealthStatDTO healthStatDTO)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState); // Returns validation errors
    }

    var healthStat = new HealthStat
    {
        PatientID = healthStatDTO.PatientID,
        DataType = healthStatDTO.DataType,
        Value = healthStatDTO.Value,
        Timestamp = healthStatDTO.Timestamp
    };

    _context.HealthStats.Add(healthStat);
    _context.SaveChanges();

    return CreatedAtAction(nameof(GetHealthStat), new { id = healthStat.StatID }, healthStat);
}
