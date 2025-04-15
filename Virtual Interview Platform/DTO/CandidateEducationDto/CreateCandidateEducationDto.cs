using System.ComponentModel.DataAnnotations;

namespace Virtual_Interview_Platform.DTO.CandidateEducationDto
{
    public class CreateCandidateEducationDto
    {
        [Required]
        public int CandidateID { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Institution { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Grade { get; set; }
        public string CreatedAt { get; set; }
    }
}
