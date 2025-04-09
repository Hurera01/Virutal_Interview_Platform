using Virtual_Interview_Platform.Data;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Repository.Interface;

namespace Virtual_Interview_Platform.Repository.Implementation
{
    public class RecruiterTestRepository: GenericRepository<Recruiter>, IRecruiterRepository
    {
        public RecruiterTestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
