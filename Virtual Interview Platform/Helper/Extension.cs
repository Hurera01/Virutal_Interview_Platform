using Virtual_Interview_Platform.Repository.Implementation;
using Virtual_Interview_Platform.Repository.Interface;
using Virtual_Interview_Platform.Services.Implementation;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Helper
{
    public static class Extension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ICandidateExperienceService, CandidateExperienceService>();
            services.AddScoped<ICandidateEducationService, CandidateEducationService>();
            services.AddScoped<IRecruiterService, RecruiterService>();
            services.AddScoped<RecruiterTestService>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRecruiterRepository, RecruiterTestRepository>();
        }
    }
}
