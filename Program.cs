using Microsoft.EntityFrameworkCore;
using YourNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register DbContext with the connection string (replace with your actual connection string).
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register UserService as a scoped service.
builder.Services.AddScoped<IUserService, UserService>();

// Add controllers and endpoints.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI/Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
