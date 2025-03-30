using backendcCTRL.Models;

namespace backendcCTRL.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment? GetAppointmentById(int id);
        Appointment CreateAppointment(Appointment appointment);
        Appointment? UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(int id);
        bool AppointmentExists(int id);
    }
}
