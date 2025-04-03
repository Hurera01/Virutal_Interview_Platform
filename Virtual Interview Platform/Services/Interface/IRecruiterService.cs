using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Services.Interface
{
    public interface IRecruiterService
    {
        Task CreateRecruiter(Recruiter recruiter);
        Task DeleteRecruiter(int recruiterId);
        Task UpdateRecruiter(Recruiter recruiter);
        Task<Recruiter> GetRecruiterById(int recruiterId);
        Task<List<Recruiter>> GetAllRecruiters();
    }
}
