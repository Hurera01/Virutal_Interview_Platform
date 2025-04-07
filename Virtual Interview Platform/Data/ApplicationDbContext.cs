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
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<Recruiter>()
                .HasOne(u => u.Users)
                .WithOne(r => r.Recruiters)
                .HasForeignKey<Recruiter>(r => r.UserID);
            
            modelBuilder.Entity<Candidate>()
                .HasOne(u => u.Users)
                .WithOne(c => c.Candidates)
                .HasForeignKey<Candidate>(c => c.UserID);

            modelBuilder.Entity<CandidateEducation>()
                .HasOne(c => c.Candidates)
                .WithMany(ce => ce.CandidateEducations)
                .HasForeignKey(ce => ce.CandidateID);

            modelBuilder.Entity<CandidateExperience>()
                .HasOne(c => c.Candidates)
                .WithMany(ce => ce.CandidateExperiences)
                .HasForeignKey(ce => ce.CandidateID);
        }
    }
}
