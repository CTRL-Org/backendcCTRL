using backendcCTRL.Data;  
using backendcCTRL.Models;
using backendcCTRL.Services.Interfaces;


namespace backendcCTRL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.AppointmentID == id);
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = _context.Appointments.Find(appointment.AppointmentID);
            if (existingAppointment == null)
                return null;

            existingAppointment.DateTime = appointment.DateTime;
            existingAppointment.Reason = appointment.Reason;
            existingAppointment.Status = appointment.Status;
            _context.SaveChanges();

            return existingAppointment;
        }

        public bool DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
                return false;

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return true;
        }
    }
}
