using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using backendcCTRL.DataAccess;
using backendcCTRL.Models;

public class DataSeeder
{
    public static void Seed(AppDbContext context)
{
    try
    {
        Console.WriteLine("Starting data seeding process...");

        // Check if any of the tables are empty
        bool shouldSeed = !context.Users.Any() || !context.Patients.Any() || !context.Appointments.Any();

        if (shouldSeed)
        {
            Console.WriteLine("No existing data found, proceeding with seeding...");

            // Create a test user
            var user = new User
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "hashedpassword",
                Role = "Admin"
            };
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine($"Created user with ID: {user.UserID}");

            // Create a test patient
            var patient = new Patient
            {
                FullName = "John Doe",
                DateOfBirth = new DateTime(1990, 5, 20).ToUniversalTime(),
                Gender = "Male",
                IDNumber = "9005201234567",
                UserID = user.UserID
            };
            context.Patients.Add(patient);
            context.SaveChanges();
            Console.WriteLine($"Created patient with ID: {patient.PatientID}");

            // Create a test provider
            var provider = new Provider
            {
                UserID = (int)user.UserID,
                LicenseNumber = "LIC123456",
                Speciality = "General Practitioner"
            };
            context.Providers.Add(provider);
            context.SaveChanges();
            Console.WriteLine($"Created provider with ID: {provider.ProviderID}");

            // Create a test appointment
            var appointment = new Appointment
            {
                PatientID = patient.PatientID ?? 0,
                ProviderID = provider.ProviderID, // Use the valid ProviderID
                DateTime = DateTime.UtcNow.AddDays(1),
                Reason = "General Checkup",
                Status = "Scheduled"
            };
            context.Appointments.Add(appointment);
            context.SaveChanges();
            Console.WriteLine($"Created appointment with ID: {appointment.AppointmentID}");

            // Create health stats for the patient
            var healthStats = new HealthStats
            {
                PatientID = patient.PatientID ?? throw new InvalidOperationException("PatientID cannot be null"),
                DataType = "Height",
                Value = "180",
                Timestamp = DateTime.UtcNow
            };
            context.HealthStats.Add(healthStats);
            context.SaveChanges();
            Console.WriteLine($"Created health stats with ID: {healthStats.StatID}");

            // Verify the data was saved
            var savedUser = context.Users.FirstOrDefault(u => u.Username == "testuser");
            var savedPatient = context.Patients.FirstOrDefault(p => p.FullName == "John Doe");
            var savedAppointment = context.Appointments.FirstOrDefault(a => a.PatientID == patient.PatientID);
            var savedHealthStats = context.HealthStats.FirstOrDefault(h => h.PatientID == patient.PatientID);

            Console.WriteLine("\nVerifying seeded data:");
            Console.WriteLine($"User exists: {savedUser != null}, ID: {savedUser?.UserID}");
            Console.WriteLine($"Patient exists: {savedPatient != null}, ID: {savedPatient?.PatientID}");
            Console.WriteLine($"Appointment exists: {savedAppointment != null}, ID: {savedAppointment?.AppointmentID}");
            Console.WriteLine($"HealthStats exists: {savedHealthStats != null}, ID: {savedHealthStats?.StatID}");
        }
        else
        {
            Console.WriteLine("Data already exists, skipping seeding.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during seeding: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
        throw;
    }
    }
}