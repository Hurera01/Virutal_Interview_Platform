using System.ComponentModel.DataAnnotations;

namespace Virtual_Interview_Platform.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public Recruiter Recruiters { get; set; }
        public Candidate Candidates { get; set; }
    }
}
