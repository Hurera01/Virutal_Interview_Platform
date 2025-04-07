using System.ComponentModel.DataAnnotations;

namespace Virtual_Interview_Platform.Model
{
    public class Recruiter
    {
        [Key]
        public int RecruiterID  { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Users { get; set; }
    }
}
