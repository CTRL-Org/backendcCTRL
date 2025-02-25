using System.Collections.Generic;
using backendcCTRL.Models;

public interface IPatientService
{
    IEnumerable<Patient> GetAllPatients();
    Patient? GetPatientById(int id);
    Patient CreatePatient(Patient patient);
    Patient? UpdatePatient(Patient patient);
    bool DeletePatient(int id);
}
