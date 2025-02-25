using Microsoft.AspNetCore.Mvc;
using backendcCTRL.DTOs;
using backendcCTRL.Services.Interfaces;
using backendcCTRL.Models;

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
    public IActionResult CreatePatient([FromBody] CreatePatientDTO patientDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var patient = new Patient
        {
            UserID = patientDTO.UserID,
            FullName = patientDTO.FullName,
            DateOfBirth = patientDTO.DateOfBirth,
            Gender = patientDTO.Gender
            
        };

        var createdPatient = _patientService.CreatePatient(patient);
        return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.PatientID }, createdPatient);
    }

    // PUT: api/Patient/{id}
    [HttpPut("{id}")]
    public IActionResult UpdatePatient(int id, [FromBody] CreatePatientDTO patientDTO)
    {
        var existingPatient = _patientService.GetPatientById(id);
        if (existingPatient == null)
        {
            return NotFound();
        }

        existingPatient.FullName = patientDTO.FullName;
        existingPatient.DateOfBirth = patientDTO.DateOfBirth;
        existingPatient.Gender = patientDTO.Gender;
        existingPatient.IdNumber = patientDTO.IdNumber;

        var updatedPatient = _patientService.UpdatePatient(existingPatient);
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
