namespace Virtual_Interview_Platform.DTO.CandidateExperienceDto
{
    public class GetCandidateExperienceDto
    {
        public int ExperienceID { get; set; }
        public int CandidateID { get; set; }
        public string CompanyName { get; set; }
        public int JobTitle { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
