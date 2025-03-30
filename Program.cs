using backendcCTRL.DataAccess;
using backendcCTRL.Services;
using backendcCTRL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Call seeder for data
try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Ensure database exists
        dbContext.Database.EnsureCreated();
        
        Console.WriteLine("Database created/verified. Starting data seeding...");
        DataSeeder.Seed(dbContext);
        Console.WriteLine("Data seeding completed successfully.");
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
