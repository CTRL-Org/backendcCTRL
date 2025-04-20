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
// Ensure database is created and seeded
try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Retry logic to handle database connection issues
        var retryCount = 5;
        var delay = 5000; // 5 seconds

        for (int i = 0; i < retryCount; i++)
        {
            try
            {
                Console.WriteLine("Ensuring database is created...");
                dbContext.Database.EnsureCreated();
                break; // Exit the loop if successful
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Attempt {i + 1}: Failed to connect to the database. Retrying in {delay / 1000} seconds...");
                Console.WriteLine($"Error: {ex.Message}");
                Thread.Sleep(delay);
            }
        }

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

app.Run("http://*:80");
