using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Repository.Interface;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class RecruiterService : GenericService<Recruiter>
    {
        private readonly IGenericRepository<Recruiter> _recruiterRepository;

        public RecruiterService(IGenericRepository<Recruiter> recruiterRepository) : base(recruiterRepository)
        {
            {
                
            }
        }
    }
}
