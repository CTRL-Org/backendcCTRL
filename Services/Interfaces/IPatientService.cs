using backendcCTRL.Models;

namespace backendcCTRL.Services.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
        Patient CreatePatient(Patient patient);
        Patient? UpdatePatient(int id, Patient patient);
        bool DeletePatient(int id);
    }
}
