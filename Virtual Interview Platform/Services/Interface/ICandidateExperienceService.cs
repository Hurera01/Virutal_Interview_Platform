using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Services.Interface
{
    public interface ICandidateExperienceService
    {
        Task CreateCandidateExperience(CandidateExperience candidateExperience);
        Task DeleteCandidateExperience(int candidateExperienceId);
        Task UpdateCandidateExperience(CandidateExperience candidateExperience);
        Task<CandidateExperience> GetCandidateExperienceById(int candidateExperienceId);
        Task<List<CandidateExperience>> GetAllCandidateExperiences();
    }
}
