using Microsoft.EntityFrameworkCore;
using HallMaintenanceAPI.Models;
using HallMaintenanceAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Configure SQLite DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=Hall_Maintenance.db"));

// Optional: Swagger for testing APIs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in dev
app.UseSwagger();
app.UseSwaggerUI();

// Remove HTTPS redirection for dev (prevents localhost connection refused)
 // app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Force HTTP on port 5000
app.Urls.Clear();
app.Urls.Add("http://localhost:5000");

app.Run();