using System.ComponentModel.DataAnnotations;

namespace Virtual_Interview_Platform.DTO.RecruiterDto
{
    public class UpdateRecruiterDto
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
