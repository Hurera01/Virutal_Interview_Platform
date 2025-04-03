using Microsoft.EntityFrameworkCore;
using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Data
{
    public class ApplicationDbContext: DbContext    
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

         public DbSet<CandidateEducation> CandidateEducations { get; set; }
         public DbSet<CandidateExperience> CandidateExperiences { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
