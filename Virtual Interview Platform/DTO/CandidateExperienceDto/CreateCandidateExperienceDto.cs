using System.ComponentModel.DataAnnotations;

namespace Virtual_Interview_Platform.DTO.CandidateExperienceDto
{
    public class CreateCandidateExperienceDto
    {
        [Required]
        public int CandidateID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int JobTitle { get; set; }
        [Required]
        public int StartDate { get; set; }
        [Required]
        public int EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
