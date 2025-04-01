using backendcCTRL.DataAccess;
using backendcCTRL.Services;
using backendcCTRL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Enable sensitive data logging for development
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine);
});

// Register application services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHealthStatsService, HealthStatsService>();
builder.Services.AddScoped<IPatientService, PatientService>();

// Add controllers and endpoints
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CTRL API", Version = "v1" });
});

var app = builder.Build();

// If --seed is passed as an argument, run the seeder and exit
if (args.Length > 1 && args[1] == "--seed")
{
    try
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            // Ensure database exists
            Console.WriteLine("Ensuring database is created...");
            dbContext.Database.EnsureCreated();

            // Run the seeder
            DataSeeder.Seed(dbContext);
        }
        
        Console.WriteLine("\nData seeding completed successfully!");
        return;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during seeding: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");
        throw;
    }
}

// Call seeder for data
try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Ensure database exists and tables are created
        Console.WriteLine("Ensuring database is created...");
        dbContext.Database.EnsureCreated();
        
        // Check tables before seeding
        var userCount = dbContext.Users.Count();
        var patientCount = dbContext.Patients.Count();
        var appointmentCount = dbContext.Appointments.Count();
        
        Console.WriteLine($"Before seeding - Users: {userCount}, Patients: {patientCount}, Appointments: {appointmentCount}");
        
        if (userCount == 0 || patientCount == 0 || appointmentCount == 0)
        {
            Console.WriteLine("Starting data seeding...");
            DataSeeder.Seed(dbContext);
            
            // Verify seeding results
            userCount = dbContext.Users.Count();
            patientCount = dbContext.Patients.Count();
            appointmentCount = dbContext.Appointments.Count();
            
            Console.WriteLine($"After seeding - Users: {userCount}, Patients: {patientCount}, Appointments: {appointmentCount}");
            
            // Try to fetch and display the actual data
            var users = dbContext.Users.ToList();
            var patients = dbContext.Patients.ToList();
            var appointments = dbContext.Appointments.ToList();
            
            Console.WriteLine("\nSeeded Data Details:");
            foreach (var user in users)
            {
                Console.WriteLine($"User: ID={user.UserID}, Username={user.Username}");
            }
            foreach (var patient in patients)
            {
                Console.WriteLine($"Patient: ID={patient.PatientID}, Name={patient.FullName}, UserID={patient.UserID}");
            }
            foreach (var appt in appointments)
            {
                Console.WriteLine($"Appointment: ID={appt.AppointmentID}, PatientID={appt.PatientID}, DateTime={appt.DateTime}");
            }
        }
        else
        {
            Console.WriteLine("Data already exists, skipping seeding.");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during database setup: {ex.Message}");
    Console.WriteLine($"Stack trace: {ex.StackTrace}");
    return;
}

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthTracker API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
