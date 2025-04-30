using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.VideoHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Your Angular dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // Important!
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSignalR();

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

app.UseRouting();
app.UseCors("AllowAngularClient");

app.UseAuthorization();

app.MapControllers();
app.MapHub<InterviewHub>("video-hub");

app.Run();
