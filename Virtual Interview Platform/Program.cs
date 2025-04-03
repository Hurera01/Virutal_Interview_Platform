using Virtual_Interview_Platform.Services.Implementation;
using Virtual_Interview_Platform.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateExperienceService, CandidateExperienceService>();
builder.Services.AddScoped<ICandidateEducationService, CandidateEducationService>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();






builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
