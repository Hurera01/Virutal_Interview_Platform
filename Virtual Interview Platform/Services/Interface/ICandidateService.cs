using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Services.Interface
{
    public interface ICandidateService
    {
        Task CreateCandidate(Candidate candidate);
        Task DeleteCandidate(int candidateId);
        Task UpdateCandidate(Candidate candidate);
        Task<Candidate> GetCandidateById(int candidateId);
        Task<List<Candidate>> GetAllCandidates();
    }
}
