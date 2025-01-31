using Microsoft.AspNetCore.Mvc;
using CTRL.Services;
using CTRL.Models;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    // GET: api/Patient
    [HttpGet]
    public IActionResult GetAllPatients()
    {
        var patients = _patientService.GetAllPatients();
        return Ok(patients);
    }

    // GET: api/Patient/{id}
    [HttpGet("{id}")]
    public IActionResult GetPatientById(int id)
    {
        var patient = _patientService.GetPatientById(id);
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }

    // POST: api/Patient
    [HttpPost]
    public IActionResult CreatePatient([FromBody] Patient patient)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdPatient = _patientService.CreatePatient(patient);
        return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.PatientID }, createdPatient);
    }

    // PUT: api/Patient/{id}
    [HttpPut("{id}")]
    public IActionResult UpdatePatient(int id, [FromBody] Patient patient)
    {
        if (id != patient.PatientID)
        {
            return BadRequest("ID mismatch");
        }

        var updatedPatient = _patientService.UpdatePatient(patient);
        if (updatedPatient == null)
        {
            return NotFound();
        }

        return Ok(updatedPatient);
    }

    // DELETE: api/Patient/{id}
    [HttpDelete("{id}")]
    public IActionResult DeletePatient(int id)
    {
        var isDeleted = _patientService.DeletePatient(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
