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
            
            if (!context.Users.Any())  // To Avoid duplicate seeding
            {
                Console.WriteLine("No existing users found, proceeding with seeding...");
                
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

                var patient = new Patient 
                { 
                    FullName = "John Doe", 
                    DateOfBirth = new DateTime(1990, 5, 20), 
                    Gender = "Male", 
                    IDNumber = "9005201234567", 
                    UserID = user.UserID  
                };
                context.Patients.Add(patient);
                context.SaveChanges();
                Console.WriteLine($"Created patient with ID: {patient.PatientID}");

                var appointment = new Appointment 
                { 
                    PatientID = patient.PatientID,
                    DateTime = DateTime.UtcNow, 
                    Reason = "General Checkup", 
                    Status = "Scheduled" 
                };
                context.Appointments.Add(appointment);
                context.SaveChanges();
                Console.WriteLine($"Created appointment with ID: {appointment.AppointmentID}");

                var healthStat = new HealthStats 
                { 
                    PatientID = patient.PatientID,
                    DataType = "Blood Pressure", 
                    Value = "120/80", 
                    Timestamp = DateTime.UtcNow 
                };
                context.HealthStats.Add(healthStat);
                context.SaveChanges();
                Console.WriteLine($"Created health stat with ID: {healthStat.StatID}");

                Console.WriteLine("Test data inserted successfully!");
            }
            else
            {
                Console.WriteLine(" Test data already exists, skipping seeding.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during seeding: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            throw; // Re-throw to ensure the error is not silently swallowed
        }
    }
}
