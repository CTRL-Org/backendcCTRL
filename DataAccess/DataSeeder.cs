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
        if (!context.Users.Any())  // Avoid duplicate seeding
        {
            var user = new User { Username = "testuser", Email = "test@example.com", PasswordHash = "hashedpassword" };
            context.Users.Add(user);
            context.SaveChanges();

            var patient = new Patient { FullName = "John Doe", DateOfBirth = new DateTime(1990, 5, 20), Gender = "Male", IDNumber = "9005201234567", UserID = user.UserID };
            context.Patients.Add(patient);
            context.SaveChanges();

            var appointment = new Appointment { PatientID = patient.PatientID, DateTime = DateTime.UtcNow, Reason = "General Checkup", Status = "Scheduled" };
            context.Appointments.Add(appointment);
            context.SaveChanges();

            var healthStat = new HealthStats { PatientID = patient.PatientID, DataType = "Blood Pressure", Value = "120/80", Timestamp = DateTime.UtcNow };
            context.HealthStats.Add(healthStat);
            context.SaveChanges();

            Console.WriteLine("✅ Test data inserted successfully!");
        }
        else
        {
            Console.WriteLine("ℹ️ Test data already exists.");
        }
    }
}
