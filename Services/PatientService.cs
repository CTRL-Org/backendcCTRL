using backendcCTRL.DataAccess;
using backendcCTRL.Models;
using backendcCTRL.Services.Interfaces;

namespace backendcCTRL.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.PatientID == id);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }
            return patient;
        }

        public Patient CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient? UpdatePatient(int id, Patient updatedPatient) // Add int id parameter
        {
            var patient = _context.Patients.Find(id); // Use id to find the patient
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found.");
            }

            // Update patient properties
            patient.FullName = updatedPatient.FullName;
            patient.DateOfBirth = updatedPatient.DateOfBirth;
            patient.Gender = updatedPatient.Gender;
            patient.IDNumber = updatedPatient.IDNumber;

            _context.SaveChanges();
            return patient;
        }



        public bool DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
                return false;

            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return true;
        }
    }
}
