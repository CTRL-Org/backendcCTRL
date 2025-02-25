using Microsoft.AspNetCore.Mvc;
using backendcCTRL.DTOs;
using backendcCTRL.Services.Interfaces;
using backendcCTRL.Models; 


[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    // Constructor
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    // GET: api/Appointment
    [HttpGet]
    public IActionResult GetAllAppointments()
    {
        var appointments = _appointmentService.GetAllAppointments();
        return Ok(appointments);
    }

    // GET: api/Appointment/{id}
    [HttpGet("{id}")]
    public IActionResult GetAppointmentById(int id)
    {
        var appointment = _appointmentService.GetAppointmentById(id);
        if (appointment == null)
        {
            return NotFound();
        }
        return Ok(appointment);
    }

    // POST: api/Appointment
    [HttpPost]
    public IActionResult CreateAppointment([FromBody] Appointment appointment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdAppointment = _appointmentService.CreateAppointment(appointment);
        return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.AppointmentID }, createdAppointment);
    }

    // PUT: api/Appointment/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateAppointment(int id, [FromBody] Appointment appointment)
    {
        if (id != appointment.AppointmentID)
        {
            return BadRequest("ID mismatch");
        }

        var updatedAppointment = _appointmentService.UpdateAppointment(appointment);
        if (updatedAppointment == null)
        {
            return NotFound();
        }

        return Ok(updatedAppointment);
    }

    // DELETE: api/Appointment/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteAppointment(int id)
    {
        var isDeleted = _appointmentService.DeleteAppointment(id);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
