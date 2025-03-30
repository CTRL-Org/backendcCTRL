using backendcCTRL.DataAccess;
using backendcCTRL.Models;
using backendcCTRL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _context.Patients.Include(p => p.User).ToList();
        }

        public Patient? GetPatientById(int id)
        {
            return _context.Patients
                .Include(p => p.User)
                .FirstOrDefault(p => p.PatientID == id);
        }

        public Patient CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient? UpdatePatient(int id, Patient updatedPatient)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
                return null;

            patient.FullName = updatedPatient.FullName;
            patient.DateOfBirth = updatedPatient.DateOfBirth;
            patient.Gender = updatedPatient.Gender;

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
