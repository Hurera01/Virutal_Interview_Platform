using System.Threading.Tasks;
using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Services.Interface
{
    public interface ICandidateEducationService
    {
        Task CreateCandidateEducation(CandidateEducation candidateEducation);
        Task DeleteCandidateEducation(int candidateEducationId);
        Task UpdateCandidateEducation(CandidateEducation candidateEducation);
        Task<CandidateEducation> GetCandidateEducationById(int candidateEducationId);
        Task<List<CandidateEducation>> GetAllCandidateEducationsByCandidateId(int candidateId);
    }
}
