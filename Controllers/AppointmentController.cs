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
    public IActionResult CreateAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = new Appointment
        {
            PatientID = appointmentDTO.PatientID,
            DateTime = appointmentDTO.DateTime,
            Reason = appointmentDTO.Reason,
            Status = "Pending" // Set status explicitly in the controller or service
        };

        var createdAppointment = _appointmentService.CreateAppointment(appointment);
        
        return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.AppointmentID }, createdAppointment);
    }


    // PUT: api/Appointment/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] UpdateAppointmentDTO appointmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAppointment = _appointmentService.GetAppointmentById(id);
            if (existingAppointment == null)
            {
                return NotFound();
            }

            // Update fields selectively
            existingAppointment.DateTime = appointmentDTO.DateTime;
            existingAppointment.Reason = appointmentDTO.Reason;
            existingAppointment.Status = appointmentDTO.Status;

            var updatedAppointment = _appointmentService.UpdateAppointment(existingAppointment);
            
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
