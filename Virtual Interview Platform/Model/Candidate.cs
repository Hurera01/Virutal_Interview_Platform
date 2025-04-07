using System.ComponentModel.DataAnnotations;

namespace Virtual_Interview_Platform.Model
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }
        public int UserID {  get; set; }
        public string ResumeURL { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Users {  get; set; }
        public ICollection<CandidateEducation> CandidateEducations { get; set; }
        public ICollection<CandidateExperience> CandidateExperiences { get; set; }
    }
}
