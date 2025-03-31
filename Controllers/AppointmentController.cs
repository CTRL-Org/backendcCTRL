using Microsoft.AspNetCore.Mvc;
using backendcCTRL.DTOs;
using backendcCTRL.Services.Interfaces;
using backendcCTRL.Models;
using Microsoft.Extensions.Logging;

namespace backendcCTRL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(IAppointmentService appointmentService, ILogger<AppointmentController> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        // GET: api/Appointment
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            _logger.LogInformation("Getting all appointments");
            try
            {
                var appointments = _appointmentService.GetAllAppointments();
                _logger.LogInformation($"Found {appointments.Count()} appointments");
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting appointments: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Appointment/{id}
        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            _logger.LogInformation($"Getting appointment with ID: {id}");
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                _logger.LogWarning($"Appointment with ID {id} not found");
                return NotFound();
            }
            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public IActionResult CreateAppointment([FromBody] CreateAppointmentDTO appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Map the DTO to the Appointment model
                var appointment = new Appointment
                {
                    PatientID = appointmentDto.PatientID,
                    DateTime = appointmentDto.DateTime,
                    Reason = appointmentDto.Reason
                };

                var createdAppointment = _appointmentService.CreateAppointment(appointment);
                _logger.LogInformation($"Created appointment with ID: {createdAppointment.AppointmentID}");
                return CreatedAtAction(nameof(GetAppointmentById), new { id = createdAppointment.AppointmentID }, createdAppointment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating appointment: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Appointment/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedAppointment = _appointmentService.UpdateAppointment(appointment);
                if (updatedAppointment == null)
                {
                    _logger.LogWarning($"Appointment with ID {id} not found");
                    return NotFound();
                }

                _logger.LogInformation($"Updated appointment with ID: {updatedAppointment.AppointmentID}");
                return Ok(updatedAppointment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating appointment: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Appointment/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            try
            {
                var deleted = _appointmentService.DeleteAppointment(id);
                if (!deleted)
                {
                    _logger.LogWarning($"Appointment with ID {id} not found");
                    return NotFound();
                }

                _logger.LogInformation($"Deleted appointment with ID: {id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting appointment: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
