using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

// Register Swagger generator (if needed).
builder.Services.AddEndpointsApiExplorer();  // Adds basic API explorer support for Swagger
builder.Services.AddSwaggerGen();  // Adds Swagger generation to the DI container

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger only in the development environment
    app.UseSwagger();
    app.UseSwaggerUI();  // Adds Swagger UI (interactive documentation)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
